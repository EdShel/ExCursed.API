using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Group;
using ExCursed.BLL.Exceptions;
using ExCursed.BLL.Interfaces;
using ExCursed.WebAPI.Models.Group;
using ExCursed.DAL.Repositories;
using ExCursed.DAL.Entities;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace ExCursed.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        private readonly IUniversityService universityService;

        private readonly ICourseService courseService;

        private readonly IEmailService emailService;

        private readonly UserRepository userRepository;

        private readonly IPasswordGenerator passwordGenerator;

        private readonly IAuthService authService;

        private readonly ILogger<GroupController> logger;

        public GroupController(
            IGroupService groupService,
            IUniversityService universityService,
            ICourseService courseService, IEmailService emailService, UserRepository userRepository, IPasswordGenerator passwordGenerator, IAuthService authService, ILogger<GroupController> logger)
        {
            this.groupService = groupService;
            this.universityService = universityService;
            this.courseService = courseService;
            this.emailService = emailService;
            this.userRepository = userRepository;
            this.passwordGenerator = passwordGenerator;
            this.authService = authService;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroupAsync([FromBody] GroupCreateRequest request)
        {
            var course = await courseService.GetCourseByIdAsync(request.CourseId);
            if (course == null)
            {
                throw new BadRequestException("Course doesn't exist");
            }
            if (!await User.IsUniversityTeacherOrHigherAsync(course.UniversityId, universityService))
            {
                throw new ForbiddenException("Don't have rights to create a group for this course!");
            }

            var dto = new CreateGroupDTO
            {
                CourseId = request.CourseId,
                TeacherEmail = request.TeacherEmail,
                Name = request.GroupName
            };
            int id = await groupService.AddGroupAsync(dto);
            return Ok(new
            {
                id
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupAsync(int id)
        {
            // TODO: Add access validation
            await groupService.DeleteGroupAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoAsync(int id)
        {
            GroupInfoDTO group = await groupService.GetGroupInfoAsync(id);

            return Ok(new
            {
                group.Id,
                group.Name,
                Students = group.Students
                    .Select(s => new
                    {
                        s.Email,
                        s.FirstName,
                        s.LastName
                    })
            });
        }

        [HttpPost("addStudent")]
        public async Task<IActionResult> AddStudentToGroupAsync([FromBody] AddStudentToGroupRequest request)
        {
            Regex nameSurnameRegex = new Regex(@"\w+");

            MatchCollection nameSurnameMatches = nameSurnameRegex.Matches(request.StudentEmail);
            if (nameSurnameMatches.Count < 2)
            {
                throw new BadRequestException(
                    $"Student email {request.StudentEmail} is invalid (doesn't contain at least 2 words).");
            }

            var existingStudent = await this.userRepository.FindByEmailAsync(request.StudentEmail);
            User userToApply;
            if (existingStudent == null)
            {
                var newStudentModel = new BLL.DTOs.Auth.StudentRegistrationDTO
                {
                    Email = request.StudentEmail,
                    Password = passwordGenerator.GeneratePassword(),
                    FirstName = CapitalizeFirstChar(nameSurnameMatches[0].Value),
                    LastName = CapitalizeFirstChar(nameSurnameMatches[1].Value),
                    UniversityId = 1
                };
                userToApply = await this.authService.RegisterStudentAsync(newStudentModel);

                this.logger.LogInformation("Password for new user {Email} is {Password}", newStudentModel.Email, newStudentModel.Password);
                await this.emailService.SendAsync(request.StudentEmail,
                    "ExCursed | Registration",
                    $@"You've been registered in ExCursed's course.<br/> You can use this password to sign in: <b>{newStudentModel.Password}</b>");
            }
            else
            {
                await this.emailService.SendAsync(request.StudentEmail,
                    "ExCursed | Applied for the course",
                    $@"You were added to the course. You can sign in using your existing account's credentials.");
                userToApply = existingStudent;
            }

            await groupService.AddStudentToGroupAsync(request.GroupId, request.StudentEmail);
            return Ok();
        }

        [HttpPost("removeStudent")]
        public async Task<IActionResult> RemoveStudentFromGroupAsync([FromBody] RemoveStudentFromGroupRequest request)
        {
            // TODO: Add access validation, and again
            await groupService.RemoveStudentFromGroupAsync(request.GroupId, request.StudentEmail);
            return Ok();
        }

        private static string CapitalizeFirstChar(string str)
        {
            return str[0].ToString().ToUpperInvariant() + str.Substring(1).ToLowerInvariant();
        }
    }
}