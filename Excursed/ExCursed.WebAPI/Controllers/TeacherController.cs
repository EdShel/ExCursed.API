using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Teacher;
using ExCursed.BLL.Interfaces;
using ExCursed.DAL.Constants;
using ExCursed.WebAPI.Models.Responses.Course;

namespace ExCursed.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        private readonly IMapper mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        [HttpGet("courses/{email}")]
        [Authorize(Roles = RoleName.ADMIN)]
        public async Task<ObjectResult> GetCoursesForTeacherAsync(string email)
        {
            var coursesRequest = new TeachersCoursesRequest { TeacherEmail = email };
            var coursesResponse = mapper.Map<IEnumerable<CourseResponse>>(await teacherService.GetTeahersCoursesAsync(coursesRequest));
            return Ok(coursesResponse);
        }

        [HttpGet("courses")]
        [Authorize(Roles = RoleName.TEACHER)]
        [Produces(typeof(TeacherCoursesReadModel))]
        public async Task<ObjectResult> GetCoursesForUserAsync()
        {
            var coursesRequest = new TeachersCoursesRequest { TeacherEmail = User.Identity.Name };
            var coursesResponse = mapper.Map<IEnumerable<CourseResponse>>(await teacherService.GetTeahersCoursesAsync(coursesRequest));
            return Ok(new TeacherCoursesReadModel
            {
                Courses = coursesResponse
            });
        }

        public class TeacherCoursesReadModel
        {
            public IEnumerable<CourseResponse> Courses { get; set; }
        }
    }
}