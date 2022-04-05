using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExCursed.BLL.DTOs;
using ExCursed.BLL.DTOs.Lesson;
using ExCursed.BLL.Interfaces;
using ExCursed.WebAPI.Models.Requests;

namespace ExCursed.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService lessonService;

        private readonly IMapper mapper;

        public LessonController(ILessonService lessonService, IMapper mapper)
        {
            this.lessonService = lessonService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonByIdAsync(int id)
        {
            var lesson = await lessonService.GetLessonByIdAsync(id);
            if (lesson != null)
            {
                return Ok(lesson);
            }

            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateLessonAsync([FromBody] CreateLessonRequest request)
        {
            if (request != null && ModelState.IsValid)
            {
                CreateLessonDTO createLessonDTO = new CreateLessonDTO 
                { 
                    Lesson = mapper.Map<LessonDTO>(request), 
                    TeacherEmail = User.Identity.Name 
                };

                if (await lessonService.AddLessonAsync(createLessonDTO))
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLessonAsync(int id)
        {
            //temporary
            if (await lessonService.DeleteLessonAsync(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
