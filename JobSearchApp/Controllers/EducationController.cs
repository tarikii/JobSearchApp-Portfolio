using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;
        private readonly IMapper _mapper;

        public EducationController(IEducationService educationService, IMapper mapper)
        {
            _educationService = educationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationDto>>> GetAllEducations()
        {
            var educations = await _educationService.GetAllEducationsAsync();
            var educationDtos = _mapper.Map<IEnumerable<EducationDto>>(educations);

            return Ok(educationDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationDto>> GetEducationById(int id)
        {
            var education = await _educationService.GetEducationByIdAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            var educationDto = _mapper.Map<EducationDto>(education);
            return Ok(educationDto);
        }

        [HttpPost]
        public async Task<ActionResult<EducationDto>> CreateEducation(CreateEducationDto createEducationDto)
        {
            var createdEducation = await _educationService.CreateEducationAsync(createEducationDto,1);

            return CreatedAtAction(nameof(GetEducationById), new { id = createdEducation.EducationId }, createdEducation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EducationDto>> UpdateEducation(int id, UpdateEducationDto updateEducationDto)
        {
            if (id != updateEducationDto.EducationId)
            {
                return BadRequest();
            }

            var updatedEducation = await _educationService.UpdateEducationAsync(id, updateEducationDto);
            if (updatedEducation == null)
            {
                return NotFound();
            }

            var educationDto = _mapper.Map<EducationDto>(updatedEducation);
            return Ok(educationDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEducation(int id)
        {
            var result = await _educationService.DeleteEducationAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
