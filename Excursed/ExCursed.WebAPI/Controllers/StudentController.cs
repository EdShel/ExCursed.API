using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Students;
using ExCursed.BLL.Interfaces;
using ExCursed.DAL.Constants;
using ExCursed.WebAPI.Models.Responses.Course;
using Microsoft.EntityFrameworkCore;
using ExCursed.DAL.Entities;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ExCursed.WebAPI.Controllers
{

    public class PublicationCreateModel
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<int> Groups { get; set; }

        public IFormFileCollection Materials { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class PublicationController : ControllerBase
    {
        private readonly DbContext dbContext;
        private readonly IFileStorageService fileStorageService;
        private readonly IMapper mapper;

        public PublicationController(DbContext dbContext, IFileStorageService fileStorageService, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.fileStorageService = fileStorageService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublication(
            [FromForm] PublicationCreateModel createModel)
        {
            if (createModel.Groups == null
                || createModel.Groups.Count() == 0)
            {
                return BadRequest(new { error = "Select at least one group." });
            }

            Publication publication = new Publication
            {
                CourseId = createModel.CourseId,
                Title = createModel.Title,
                Description = createModel.Description
            };

            await dbContext.Set<Publication>().AddAsync(publication);

            foreach (var material in createModel.Materials)
            {
                string fileId = Guid.NewGuid().ToString();
                string fileUrl = await fileStorageService.SaveFileAsync(fileId, material);
                PublicationMaterial materialEntity = new PublicationMaterial
                {
                    FileName = Path.GetFileName(material.FileName),
                    PublicationId = publication.Id,
                    Url = fileUrl,
                };
                await dbContext.Set<PublicationMaterial>().AddAsync(materialEntity);
            }

            await dbContext.Set<PublicationGroup>()
                .AddRangeAsync(createModel.Groups.Select(groupId =>
                    new PublicationGroup { GroupId = groupId, PublicationId = publication.Id }));

            await dbContext.SaveChangesAsync();

            return Ok(new { publicationId = publication.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Publication publication = await dbContext.Set<Publication>()
                .FirstOrDefaultAsync(p => p.Id == id);
            if (publication == null)
            {
                return NotFound(new { error = "Publication not exists." });
            }
            dbContext.Set<Publication>().Remove(publication);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }
    }

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
            var coursesRequest = new StudentsCoursesRequest { StudentEmail = User.Identity.Name };
            var coursesResponse = mapper.Map<IEnumerable<CourseResponse>>(await studentsService.GetStudentsCoursesAsync(coursesRequest));
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
            string currentUserEmail = User.Identity.Name;

            var publicationsList = await dbContext.Set<Publication>()
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
                .OrderByDescending(p => p.Added)
                .AsNoTracking()
                .ToListAsync();
            var model = mapper.Map<IEnumerable<PublicationModel>>(publicationsList);
            return Ok(new StudentFeedModel { Publications = model });
        }
    }

    public class StudentFeedModel
    {
        public IEnumerable<PublicationModel> Publications { get; set; }
    }

    public class PublicationModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<PublicationMaterialModel> Materials { get; set; }

        public List<PublicationGroupModel> PublicationGroups { get; set; }

        public CourseResponse Course { get; set; }
    }

    public class PublicationMaterialModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Url { get; set; }
    }

    public class PublicationGroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
