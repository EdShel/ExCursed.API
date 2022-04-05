using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExCursed.BLL.DTOs.University;
using ExCursed.BLL.Interfaces;

namespace ExCursed.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService universityService;

        public UniversityController(IUniversityService universityService)
        {
            this.universityService = universityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniversityDTO>>> GetAll()
        {
            return Ok(await universityService.GetUniversities());
        }
    }
}
