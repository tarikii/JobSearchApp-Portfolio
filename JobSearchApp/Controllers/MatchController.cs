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
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetAllMatches()
        {
            var matches = await _matchService.GetAllMatchesAsync();
            var matchDtos = _mapper.Map<IEnumerable<MatchDto>>(matches);

            return Ok(matchDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDto>> GetMatchById(int id)
        {
            var match = await _matchService.GetMatchByIdAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            var matchDto = _mapper.Map<MatchDto>(match);
            return Ok(matchDto);
        }

        [HttpPost]
        public async Task<ActionResult<MatchDto>> CreateMatch(CreateMatchDto createMatchDto)
        {
            var createdMatch = await _matchService.CreateMatchAsync(createMatchDto);

            return CreatedAtAction(nameof(GetMatchById), new { id = createdMatch.MatchId }, createdMatch);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MatchDto>> UpdateMatch(int id, UpdateMatchDto updateMatchDto)
        {
            if (id != updateMatchDto.MatchId)
            {
                return BadRequest();
            }

            var updatedMatch = await _matchService.UpdateMatchAsync(id, updateMatchDto);
            if (updatedMatch == null)
            {
                return NotFound();
            }

            var matchDto = _mapper.Map<MatchDto>(updatedMatch);
            return Ok(matchDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatch(int id)
        {
            var result = await _matchService.DeleteMatchAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
