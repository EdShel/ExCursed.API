﻿using AutoMapper;
using ExCursed.BLL.DTOs.Students;
using ExCursed.BLL.Interfaces;
using ExCursed.DAL.Constants;
using ExCursed.DAL.Entities;
using ExCursed.WebAPI.Models.Responses.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExCursed.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentsService;

        private readonly DbContext dbContext;

        private readonly IMapper mapper;

        public StudentsController(IStudentService studentsService, IMapper mapper, DbContext dbContext)
        {
            this.studentsService = studentsService;
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        //[HttpGet("courses/{email}")]
        //[Authorize(Roles = RoleName.ADMIN)]
        //public async Task<ObjectResult> GetCoursesForStudent(string email)
        //{
        //    var coursesRequest = new StudentsCoursesRequest { StudentEmail = email };
        //    var coursesResponse = mapper.Map<IEnumerable<CourseResponse>>(await studentsService.GetStudentsCoursesAsync(coursesRequest));
        //    return Ok(coursesResponse);
        //}

        [HttpGet("courses")]
        [Authorize(Roles = RoleName.STUDENT)]
        public async Task<ObjectResult> GetCoursesForUserAsync()
        {
            var coursesRequest = new StudentsCoursesRequest { StudentEmail = this.User.Identity.Name };
            var coursesResponse = this.mapper.Map<IEnumerable<CourseResponse>>(await this.studentsService.GetStudentsCoursesAsync(coursesRequest));
            return Ok(coursesResponse);
        }

        /// <summary>
        /// List of the most recent publications.
        /// </summary>
        [HttpGet("feed")]
        [Authorize(Roles = RoleName.STUDENT)]
        [Produces(typeof(StudentFeedModel))]
        public async Task<IActionResult> GetFeed()
        {
            string currentUserEmail = this.User.Identity.Name;

            var publicationsList = (await this.dbContext.Set<Publication>()
                .Where(p => p.PublicationGroups.Any(
                        pg => pg.Group.StudentGroups.Any(
                            sg => sg.Student.User.Email == currentUserEmail
                        )
                    )
                )
                .Include(p => p.Materials)
                .Include(p => p.Course)
                .Include(p => p.PublicationGroups)
                .ThenInclude(pg => pg.Group)
                .AsNoTracking()
                .ToListAsync())
                .OrderByDescending(p => p.Added)
                .ToList();
            var model = this.mapper.Map<IEnumerable<PublicationModel>>(publicationsList);
            return Ok(new StudentFeedModel { Publications = model });
        }
    }

    public class StudentFeedModel
    {
        public IEnumerable<PublicationModel> Publications { get; set; }
    }
}
