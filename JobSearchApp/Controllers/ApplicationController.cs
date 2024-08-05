using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationController(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetAllApplications()
        {
            var applications = await _applicationService.GetAllApplicationsAsync();
            var applicationDtos = _mapper.Map<IEnumerable<ApplicationDto>>(applications);

            return Ok(applicationDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationDto>> GetApplicationById(int id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            var applicationDto = _mapper.Map<ApplicationDto>(application);
            return Ok(applicationDto);
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationDto>> CreateApplication(CreateApplicationDto createApplicationDto)
        {
            var createdApplication = await _applicationService.CreateApplicationAsync(createApplicationDto);
            var applicationDto = _mapper.Map<ApplicationDto>(createdApplication);

            return CreatedAtAction(nameof(GetApplicationById), new { id = applicationDto.ApplicationId }, applicationDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApplicationDto>> UpdateApplication(int id, UpdateApplicationDto updateApplicationDto)
        {
            if (id != updateApplicationDto.ApplicationId)
            {
                return BadRequest();
            }

            var updatedApplication = await _applicationService.UpdateApplicationAsync(id, updateApplicationDto);
            if (updatedApplication == null)
            {
                return NotFound();
            }

            var applicationDto = _mapper.Map<ApplicationDto>(updatedApplication);
            return Ok(applicationDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApplication(int id)
        {
            var result = await _applicationService.DeleteApplicationAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
