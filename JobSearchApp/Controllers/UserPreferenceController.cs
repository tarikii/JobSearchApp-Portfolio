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
    public class UserPreferenceController : ControllerBase
    {
        private readonly IUserPreferenceService _userPreferenceService;
        private readonly IMapper _mapper;

        public UserPreferenceController(IUserPreferenceService userPreferenceService, IMapper mapper)
        {
            _userPreferenceService = userPreferenceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPreferenceDto>>> GetAllUserPreferences()
        {
            var preferences = await _userPreferenceService.GetAllUserPreferencesAsync();
            var preferenceDtos = _mapper.Map<IEnumerable<UserPreferenceDto>>(preferences);

            return Ok(preferenceDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserPreferenceDto>> GetUserPreferenceById(int id)
        {
            var preference = await _userPreferenceService.GetUserPreferenceByIdAsync(id);
            if (preference == null)
            {
                return NotFound();
            }
            var preferenceDto = _mapper.Map<UserPreferenceDto>(preference);
            return Ok(preferenceDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserPreferenceDto>> CreateUserPreference(CreateUserPreferenceDto createPreferenceDto)
        {
            var createdPreference = await _userPreferenceService.CreateUserPreferenceAsync(createPreferenceDto);

            return CreatedAtAction(nameof(GetUserPreferenceById), new { id = createdPreference.PreferenceId }, createdPreference);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserPreferenceDto>> UpdateUserPreference(int id, UpdateUserPreferenceDto updatePreferenceDto)
        {
            if (id != updatePreferenceDto.PreferenceId)
            {
                return BadRequest();
            }

            var updatedPreference = await _userPreferenceService.UpdateUserPreferenceAsync(id, updatePreferenceDto);
            if (updatedPreference == null)
            {
                return NotFound();
            }

            var preferenceDto = _mapper.Map<UserPreferenceDto>(updatedPreference);
            return Ok(preferenceDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserPreference(int id)
        {
            var result = await _userPreferenceService.DeleteUserPreferenceAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
