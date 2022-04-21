using AutoMapper;
using ExCursed.BLL.Interfaces;
using ExCursed.DAL.Entities;
using ExCursed.WebAPI.Models.Responses.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExCursed.WebAPI.Controllers
{
    public class PublicationCreateModel
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<int> Groups { get; set; }

        public IFormFileCollection Materials { get; set; }

        public DateTimeOffset Added { get; set; }
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

            await this.dbContext.Set<Publication>().AddAsync(publication);
            await this.dbContext.SaveChangesAsync();

            foreach (var material in createModel.Materials ?? Enumerable.Empty<IFormFile>())
            {
                string fileId = Guid.NewGuid().ToString();
                string fileUrl = await this.fileStorageService.SaveFileAsync(fileId, material);
                PublicationMaterial materialEntity = new PublicationMaterial
                {
                    FileName = Path.GetFileName(material.FileName),
                    PublicationId = publication.Id,
                    Url = fileUrl,
                };
                await this.dbContext.Set<PublicationMaterial>().AddAsync(materialEntity);
            }

            await this.dbContext.Set<PublicationGroup>()
                .AddRangeAsync(createModel.Groups.Select(groupId =>
                    new PublicationGroup { GroupId = groupId, PublicationId = publication.Id }));

            await this.dbContext.SaveChangesAsync();

            return Ok(new { publicationId = publication.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Publication publication = await this.dbContext.Set<Publication>()
                .FirstOrDefaultAsync(p => p.Id == id);
            if (publication == null)
            {
                return NotFound(new { error = "Publication not exists." });
            }
            this.dbContext.Set<Publication>().Remove(publication);
            await this.dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
