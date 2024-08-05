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
    public class CompensationBenefitController : ControllerBase
    {
        private readonly ICompensationBenefitService _compensationBenefitService;
        private readonly IMapper _mapper;

        public CompensationBenefitController(ICompensationBenefitService compensationBenefitService, IMapper mapper)
        {
            _compensationBenefitService = compensationBenefitService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompensationBenefitDto>>> GetAllCompensationBenefits()
        {
            var benefits = await _compensationBenefitService.GetAllCompensationBenefitsAsync();
            var benefitDtos = _mapper.Map<IEnumerable<CompensationBenefitDto>>(benefits);

            return Ok(benefitDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompensationBenefitDto>> GetCompensationBenefitById(int id)
        {
            var benefit = await _compensationBenefitService.GetCompensationBenefitByIdAsync(id);
            if (benefit == null)
            {
                return NotFound();
            }
            var benefitDto = _mapper.Map<CompensationBenefitDto>(benefit);
            return Ok(benefitDto);
        }

        [HttpPost]
        public async Task<ActionResult<CompensationBenefitDto>> CreateCompensationBenefit(CreateCompensationBenefitDto createBenefitDto)
        {
            var createdBenefit = await _compensationBenefitService.CreateCompensationBenefitAsync(createBenefitDto);

            return CreatedAtAction(nameof(GetCompensationBenefitById), new { id = createdBenefit.BenefitId }, createdBenefit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompensationBenefitDto>> UpdateCompensationBenefit(int id, UpdateCompensationBenefitDto updateBenefitDto)
        {
            if (id != updateBenefitDto.BenefitId)
            {
                return BadRequest();
            }

            var updatedBenefit = await _compensationBenefitService.UpdateCompensationBenefitAsync(id, updateBenefitDto);
            if (updatedBenefit == null)
            {
                return NotFound();
            }

            var benefitDto = _mapper.Map<CompensationBenefitDto>(updatedBenefit);
            return Ok(benefitDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompensationBenefit(int id)
        {
            var result = await _compensationBenefitService.DeleteCompensationBenefitAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
