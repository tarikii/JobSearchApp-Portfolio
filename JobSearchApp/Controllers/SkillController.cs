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
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetAllSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            var skillDtos = _mapper.Map<IEnumerable<SkillDto>>(skills);

            return Ok(skillDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDto>> GetSkillById(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            var skillDto = _mapper.Map<SkillDto>(skill);
            return Ok(skillDto);
        }

        [HttpPost]
        public async Task<ActionResult<SkillDto>> CreateSkill(CreateSkillDto createSkillDto)
        {
            var createdSkill = await _skillService.CreateSkillAsync(createSkillDto);

            return CreatedAtAction(nameof(GetSkillById), new { id = createdSkill.SkillId }, createdSkill);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SkillDto>> UpdateSkill(int id, UpdateSkillDto updateSkillDto)
        {
            if (id != updateSkillDto.SkillId)
            {
                return BadRequest();
            }

            var updatedSkill = await _skillService.UpdateSkillAsync(id, updateSkillDto);
            if (updatedSkill == null)
            {
                return NotFound();
            }

            var skillDto = _mapper.Map<SkillDto>(updatedSkill);
            return Ok(skillDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSkill(int id)
        {
            var result = await _skillService.DeleteSkillAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
