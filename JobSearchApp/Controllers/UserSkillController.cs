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
    public class UserSkillController : ControllerBase
    {
        private readonly IUserSkillService _userSkillService;
        private readonly IMapper _mapper;

        public UserSkillController(IUserSkillService userSkillService, IMapper mapper)
        {
            _userSkillService = userSkillService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSkillDto>>> GetAllUserSkills()
        {
            var skills = await _userSkillService.GetAllUserSkillsAsync();
            var skillDtos = _mapper.Map<IEnumerable<UserSkillDto>>(skills);

            return Ok(skillDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserSkillDto>> GetUserSkillById(int id)
        {
            var skill = await _userSkillService.GetUserSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            var skillDto = _mapper.Map<UserSkillDto>(skill);
            return Ok(skillDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserSkillDto>> CreateUserSkill(CreateUserSkillDto createSkillDto)
        {
            var createdSkill = await _userSkillService.CreateUserSkillAsync(createSkillDto);

            return CreatedAtAction(nameof(GetUserSkillById), new { id = createdSkill.UserSkillId }, createdSkill);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserSkillDto>> UpdateUserSkill(int id, UpdateUserSkillDto updateSkillDto)
        {
            if (id != updateSkillDto.UserSkillId)
            {
                return BadRequest();
            }

            var updatedSkill = await _userSkillService.UpdateUserSkillAsync(id, updateSkillDto);
            if (updatedSkill == null)
            {
                return NotFound();
            }

            var skillDto = _mapper.Map<UserSkillDto>(updatedSkill);
            return Ok(skillDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserSkill(int id)
        {
            var result = await _userSkillService.DeleteUserSkillAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
