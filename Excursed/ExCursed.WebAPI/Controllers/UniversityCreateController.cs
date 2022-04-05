﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.UniversityRequest;
using ExCursed.BLL.Interfaces;
using ExCursed.DAL.Constants;
using ExCursed.WebAPI.Models.UniversityCreation;

namespace ExCursed.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityCreateController : ControllerBase
    {
        private readonly IUniversityRequestService universityCreationService;

        private readonly IMapper mapper;

        public UniversityCreateController(IUniversityRequestService universityCreationService, IMapper mapper)
        {
            this.universityCreationService = universityCreationService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> MakeCreationRequestAsync([FromBody] UniversityCreateRequestRequest request)
        {
            var dto = mapper.Map<UniversityCreateRequestDTO>(request);
            await universityCreationService.AddRequestAsync(dto);
            return Ok();
        }

        [HttpGet, Authorize(Roles = RoleName.ADMIN)]
        public async Task<ActionResult<IEnumerable<UniversityCreateRequestViewDTO>>> GetAllRequestsAsync()
        {
            IEnumerable<UniversityCreateRequestViewDTO> requests = await universityCreationService.GetAllRequestsAsync();
            IEnumerable<UniversityCreateRequestModel> models = mapper.Map<IEnumerable<UniversityCreateRequestModel>>(requests);
            return Ok(models);
        }

        [HttpPost("approve"), Authorize(Roles = RoleName.ADMIN)]
        public async Task<IActionResult> ApproveRequestAsync([FromBody] ApproveUniversityCreationRequest request)
        {
            await universityCreationService.ApproveRequestAsync(request.Id);
            return Ok();
        }

        [HttpPost("reject"), Authorize(Roles = RoleName.ADMIN)]
        public async Task<IActionResult> RejectRequestAsync([FromBody] RejectUniversityCreationRequest request)
        {
            await universityCreationService.RejectRequestAsync(request.Id);
            return Ok();
        }
    }
}