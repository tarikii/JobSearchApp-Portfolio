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
    public class WorkExperienceController : ControllerBase
    {
        private readonly IWorkExperienceService _workExperienceService;
        private readonly IMapper _mapper;

        public WorkExperienceController(IWorkExperienceService workExperienceService, IMapper mapper)
        {
            _workExperienceService = workExperienceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkExperienceDto>>> GetAllWorkExperiences()
        {
            var experiences = await _workExperienceService.GetAllWorkExperiencesAsync();
            var experienceDtos = _mapper.Map<IEnumerable<WorkExperienceDto>>(experiences);

            return Ok(experienceDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkExperienceDto>> GetWorkExperienceById(int id)
        {
            var experience = await _workExperienceService.GetWorkExperienceByIdAsync(id);
            if (experience == null)
            {
                return NotFound();
            }
            var experienceDto = _mapper.Map<WorkExperienceDto>(experience);
            return Ok(experienceDto);
        }

        [HttpPost]
        public async Task<ActionResult<WorkExperienceDto>> CreateWorkExperience(CreateWorkExperienceDto createExperienceDto)
        {
            var createdExperience = await _workExperienceService.CreateWorkExperienceAsync(createExperienceDto);

            return CreatedAtAction(nameof(GetWorkExperienceById), new { id = createdExperience.WorkExperienceId }, createdExperience);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WorkExperienceDto>> UpdateWorkExperience(int id, UpdateWorkExperienceDto updateExperienceDto)
        {
            if (id != updateExperienceDto.WorkExperienceId)
            {
                return BadRequest();
            }

            var updatedExperience = await _workExperienceService.UpdateWorkExperienceAsync(id, updateExperienceDto);
            if (updatedExperience == null)
            {
                return NotFound();
            }

            var experienceDto = _mapper.Map<WorkExperienceDto>(updatedExperience);
            return Ok(experienceDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkExperience(int id)
        {
            var result = await _workExperienceService.DeleteWorkExperienceAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
