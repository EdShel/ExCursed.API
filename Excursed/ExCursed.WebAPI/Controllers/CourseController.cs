﻿using AutoMapper;
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

        public CourseController(
            ICourseService courseService, 
            IUniversityService universityService, 
            ITeacherService teacherService,
            IFileStorageService fileStorageService,
            IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
            this.universityService = universityService;
            this.teacherService = teacherService;
            this.fileStorageService = fileStorageService;
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseByIdAsync(int id)
        {
            var course = await courseService.GetCourseByIdAsync(id);
            if (course != null)
            {
                return Ok(course);
            }

            return BadRequest();
        }

        // GET: api/Course/5
        [HttpGet("{id}/Lessons")]
        public async Task<IActionResult> GetCourseWithLessonsByIdAsync(int id)
        {
            var course = await courseService.GetCourseWithLessonsByIdAsync(id);
            if (course != null)
            {
                CourseWithLessonsResponse response = new CourseWithLessonsResponse
                {
                    Course = mapper.Map<CourseResponse>(course),
                    ListLessons = mapper.Map<IEnumerable<LessonResponse>>(course.Lessons)
                };

                return Ok(response);
            }

            return BadRequest();
        }

        // POST: api/Course
        [HttpPost]
        [Authorize(Roles = RoleName.TEACHER)]
        public async Task<IActionResult> CreateCourseAsync([FromForm] CreateCourseRequest request)
        {
            if (request != null && ModelState.IsValid)
            {
                var courseDto = mapper.Map<CreateCourseRequest, CourseDTO>(request);
                courseDto.TeacherEmail = User.Identity.Name;
                courseDto.UniversityId = (await teacherService
                    .GetTeacherInfoByEmailAsync(User.Identity.Name)).UniversityId;
                courseDto.ImagePath = request.Image != null ?
                    await fileStorageService.SaveImageAsync(Guid.NewGuid() + request.Image.FileName, request.Image) : null;
                await courseService.AddCourseAsync(courseDto);
                return Ok();
            }

            return BadRequest();
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