using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Course;
using ExCursed.BLL.Exceptions;
using ExCursed.BLL.Interfaces;
using ExCursed.DAL.Constants;
using ExCursed.WebAPI.Models.Course;
using ExCursed.WebAPI.Models.Requests;
using ExCursed.WebAPI.Models.Responses.Course;
using ExCursed.WebAPI.Models.Responses.Lesson;
using System.Text.RegularExpressions;
using ExCursed.BLL.Services;
using ExCursed.DAL.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ExCursed.DAL.Entities;

namespace ExCursed.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        private readonly IMapper mapper;

        private readonly IUniversityService universityService;

        private readonly ITeacherService teacherService;

        private readonly IFileStorageService fileStorageService;

        private readonly IGroupService groupService;

        private readonly IAuthService authService;

        private readonly UserRepository userRepository;

        private readonly IEmailService emailService;

        private readonly ILogger<CourseController> logger;

        private readonly DbContext dbContext;

        public CourseController(
            ICourseService courseService,
            IUniversityService universityService,
            ITeacherService teacherService,
            IFileStorageService fileStorageService,
            IMapper mapper, IGroupService groupService, IAuthService authService, UserRepository userRepository, IEmailService emailService, ILogger<CourseController> logger, DbContext dbContext)
        {
            this.courseService = courseService;
            this.mapper = mapper;
            this.universityService = universityService;
            this.teacherService = teacherService;
            this.fileStorageService = fileStorageService;
            this.groupService = groupService;
            this.authService = authService;
            this.userRepository = userRepository;
            this.emailService = emailService;
            this.logger = logger;
            this.dbContext = dbContext;
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        [Produces(typeof(CourseReadModel))]
        public async Task<IActionResult> GetCourseByIdAsync(int id)
        {
            var course = await courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return BadRequest();
            }

            var publications = await dbContext.Set<Publication>()
                .Where(p => p.CourseId == id)
                .Include(p => p.Materials)
                .Include(p => p.PublicationGroups)
                .ThenInclude(pg => pg.Group)
                .Include(p => p.Course)
                .OrderByDescending(p => p.Added)
                .ToListAsync();
            var publcicationsModel = mapper.Map<IEnumerable<PublicationModel>>(publications);

            return Ok(new CourseReadModel
            {
                Course = course,
                Publications = publcicationsModel
            });
        }

        public class CourseReadModel
        {
            public CourseDTO Course { get; set; }
            public IEnumerable<PublicationModel> Publications { get; set; }
        }

        // GET: api/Course/5
        //[HttpGet("{id}/Lessons")]
        //public async Task<IActionResult> GetCourseWithLessonsByIdAsync(int id)
        //{
        //    var course = await courseService.GetCourseWithLessonsByIdAsync(id);
        //    if (course != null)
        //    {
        //        CourseWithLessonsResponse response = new CourseWithLessonsResponse
        //        {
        //            Course = mapper.Map<CourseResponse>(course),
        //            ListLessons = mapper.Map<IEnumerable<LessonResponse>>(course.Lessons)
        //        };

        //        return Ok(response);
        //    }

        //    return BadRequest();
        //}

        // POST: api/Course
        [HttpPost]
        [Authorize(Roles = RoleName.TEACHER)]
        public async Task<IActionResult> CreateCourseAsync([FromForm] CreateCourseRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var courseDto = mapper.Map<CreateCourseRequest, CourseDTO>(request);
            courseDto.TeacherEmail = User.Identity.Name;
            courseDto.UniversityId = (await teacherService
                .GetTeacherInfoByEmailAsync(User.Identity.Name)).UniversityId;
            courseDto.ImagePath = request.Image != null ?
                await fileStorageService.SaveFileAsync(Guid.NewGuid() + request.Image.FileName, request.Image) : null;
            int courseId = await courseService.AddCourseAsync(courseDto);

            Regex studentsRegex = new Regex(@"^(.+?)\s(.+)$");
            Regex nameSurnameRegex = new Regex(@"\w+");
            var passwordGenerator = new PasswordGenerator();
            foreach (Match match in studentsRegex.Matches(request.Students))
            {
                string studentEmail = match.Groups[1].Value;
                string groupName = match.Groups[2].Value;

                var groupInfo = await groupService.GetGroupInfoOrNullByGroupNameAsync(courseId, groupName);
                int groupId;
                if (groupInfo == null)
                {
                    groupId = await groupService.AddGroupAsync(new BLL.DTOs.Group.CreateGroupDTO
                    {
                        CourseId = courseId,
                        Name = groupName,
                        TeacherEmail = User.Identity.Name
                    });
                }
                else
                {
                    groupId = groupInfo.Id;
                }

                MatchCollection nameSurnameMatches = nameSurnameRegex.Matches(studentEmail);
                if (nameSurnameMatches.Count < 2)
                {
                    throw new BadRequestException(
                        $"Student email {studentEmail} is invalid (doesn't contain at least 2 words).");
                }

                var existingStudent = await userRepository.FindByEmailAsync(studentEmail);
                if (existingStudent == null)
                {
                    var newStudentModel = new BLL.DTOs.Auth.StudentRegistrationDTO
                    {
                        Email = studentEmail,
                        Password = passwordGenerator.GeneratePassword(),
                        FirstName = CapitalizeFirstChar(nameSurnameMatches[0].Value),
                        LastName = CapitalizeFirstChar(nameSurnameMatches[1].Value),
                        UniversityId = 1
                    };
                    await authService.RegisterStudentAsync(newStudentModel);

                    logger.LogInformation("Password for new user {Email} is {Password}", newStudentModel.Email, newStudentModel.Password);
                    await emailService.SendAsync(studentEmail,
                        "ExCursed | Registration",
                        $@"You've been registered in ExCursed's course <i>${request.Title}.<i/><br/> You can use this password to sign in: <b>${newStudentModel.Email}</b>");
                }
                else
                {
                    await emailService.SendAsync(studentEmail,
                        "ExCursed | Applied for the course",
                        $@"You were added to the course <i>${request.Title}.<i/> You can sign in using your existing account's credentials.");
                }
            }

            return Ok();
        }

        private static string CapitalizeFirstChar(string str)
        {
            return str[0].ToString().ToUpperInvariant() + str.Substring(1).ToLowerInvariant();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleName.TEACHER)]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            //temporary
            if (await courseService.DeleteCourseAsync(id))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("addTeacher")]
        public async Task<IActionResult> AddTeacherAsync([FromBody] AddTeacherRequest request)
        {
            CourseDTO course = await courseService.GetCourseByIdAsync(request.CourseId);
            if (course == null)
            {
                throw new BadRequestException("Course doesn't exist");
            }
            if (!await User.IsUniversityTeacherOrHigherAsync(course.UniversityId, universityService))
            {
                throw new ForbiddenException("Don't have rights to access the course!");
            }

            await courseService.AddCourseMemberAsync(request.CourseId, request.TeacherEmail);
            return Ok();
        }

        [HttpPost("removeTeacher")]
        public async Task<IActionResult> RemoveTeacherAsync([FromBody] RemoveTeacherRequest request)
        {
            CourseDTO course = await courseService.GetCourseByIdAsync(request.CourseId);
            if (course == null)
            {
                throw new BadRequestException("Course doesn't exist");
            }
            if (!await User.IsUniversityTeacherOrHigherAsync(course.UniversityId, universityService))
            {
                throw new ForbiddenException("Don't have rights to access the course!");
            }

            await courseService.RemoveCourseMemberAsync(request.CourseId, request.TeacherEmail);
            return Ok();
        }

        [HttpGet("{id}/teachers")]
        public IActionResult GetAllTeachers(int id)
        {
            IEnumerable<CourseMemberDTO> teachers = courseService.GetCourseMembers(id);
            return Ok(teachers.Select(t => new
            {
                t.Email,
                t.FirstName,
                t.LastName
            }));
        }
    }
}