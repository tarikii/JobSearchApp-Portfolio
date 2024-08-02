using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
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
        public async Task<ActionResult<IEnumerable<EducationDto>>> GetAll()
        {
            var studies = await _educationService.GetAllEducationsAsync();
            var educationDto = _mapper.Map<IEnumerable<EducationDto>>(studies);

            return Ok(educationDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationDto>> GetById(int id)
        {
            var education = await _educationService.GetEducationByIdAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            var educationDto = _mapper.Map<EducationDto>(education);
            return Ok(educationDto);
        }
    }

    // [HttpPost]
    // public async Task<ActionResult<EducationDto>> Create(CreateEducationDto createEducationDto)
    // {
    //     var education = _mapper.Map<Education>(createEducationDto);
    //     var createdEducation = await _educationService.CreateEducationAsync(education);
    //     var educationDto = _mapper.Map<EducationDto>(createdEducation);
    //
    //     return CreatedAtAction(nameof(GetById), new { id = educationDto.EducationId }, educationDto);
    // }
    //
    // [HttpPut("{id}")]
    // public async Task<ActionResult<EducationDto>> Update(int id, UpdateEducationDto updateEducationDto)
    // {
    //     if (id != updateEducationDto.EducationId)
    //     {
    //         return BadRequest();
    //     }
    //
    //     var education = _mapper.Map<User>(updateEducationDto);
    //     var updatedUser = await _educationService.UpdateEducationAsync(education);
    //     var educationDto = _mapper.Map<EducationDto>(updatedUser);
    //
    //     return Ok(educationDto);
    // }
    //
    // [HttpDelete("{id}")]
    // public async Task<ActionResult> DeleteUser(int id)
    // {
    //     var result = await _educationService.DeleteEducationAsync(id);
    //     if (!result)
    //     {
    //         return NotFou    nd();
}

//return NoContent();