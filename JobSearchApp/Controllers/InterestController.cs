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
    public class InterestController : ControllerBase
    {
        private readonly IInterestService _interestService;
        private readonly IMapper _mapper;

        public InterestController(IInterestService interestService, IMapper mapper)
        {
            _interestService = interestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterestDto>>> GetAllInterests()
        {
            var interests = await _interestService.GetAllInterestsAsync();
            var interestDtos = _mapper.Map<IEnumerable<InterestDto>>(interests);

            return Ok(interestDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InterestDto>> GetInterestById(int id)
        {
            var interest = await _interestService.GetInterestByIdAsync(id);
            if (interest == null)
            {
                return NotFound();
            }
            var interestDto = _mapper.Map<InterestDto>(interest);
            return Ok(interestDto);
        }

        [HttpPost]
        public async Task<ActionResult<InterestDto>> CreateInterest(CreateInterestDto createInterestDto)
        {
            var createdInterest = await _interestService.CreateInterestAsync(createInterestDto, 1);

            return CreatedAtAction(nameof(GetInterestById), new { id = createdInterest.InterestId }, createdInterest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InterestDto>> UpdateInterest(int id, UpdateInterestDto updateInterestDto)
        {
            if (id != updateInterestDto.InterestId)
            {
                return BadRequest();
            }

            var updatedInterest = await _interestService.UpdateInterestAsync(id, updateInterestDto);
            if (updatedInterest == null)
            {
                return NotFound();
            }

            var interestDto = _mapper.Map<InterestDto>(updatedInterest);
            return Ok(interestDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInterest(int id)
        {
            var result = await _interestService.DeleteInterestAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
