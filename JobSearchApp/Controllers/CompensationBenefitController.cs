using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompensationBenefitController : ControllerBase
    {
        private readonly ICompensationBenefitService _compesationBenefitService;
        private readonly IMapper _mapper;

        public CompensationBenefitController(ICompensationBenefitService compensationBenefitService, IMapper mapper)
        {
            _compesationBenefitService = compensationBenefitService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompensationBenefitDto>>> GetAllCompensationBenefits()
        {
            var benefits = await _compesationBenefitService.GetAllCompensationBenefitsAsync();
            var benefitsDto = _mapper.Map<IEnumerable<CompensationBenefitDto>>(benefits);

            return Ok(benefitsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompensationBenefitDto>> GetCompensationBenefitById(int id)
        {
            var benefitDto = await _compesationBenefitService.GetCompensationBenefitByIdAsync(id);
            if (benefitDto == null)
            {
                return NotFound();
            }
            var benefitDtoDto = _mapper.Map<CompensationBenefitDto>(benefitDto);
            return Ok(benefitDtoDto);
        }

        [HttpPost]
        public async Task<ActionResult<CompensationBenefitDto>> CreateCompensationBenefit(CreateCompensationBenefitDto createCompensationBenefitDto)
        {
            var benefit = _mapper.Map<CompensationBenefit>(createCompensationBenefitDto);
            var createdCompensationenefit = await _compesationBenefitService.CreateCompensationBenefitAsync(benefit);
            var benefitDto = _mapper.Map<CompensationBenefitDto>(createdCompensationenefit);

            return CreatedAtAction(nameof(GetCompensationBenefitById), new { id = benefitDto.BenefitId }, benefitDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompensationBenefitDto>> UpdateCompensationBenefit(int id, UpdateCompensationBenefitDto updateBenefitDto)
        {
            if (id != updateBenefitDto.BenefitId)
            {
                return BadRequest();
            }

            var benefitDto = _mapper.Map<CompensationBenefit>(updateBenefitDto);
            var updatedCompensationBenefit = await _compesationBenefitService.UpdateCompensationBenefitAsync(benefitDto);
            var benefitDtoDto = _mapper.Map<CompensationBenefitDto>(updatedCompensationBenefit);

            return Ok(benefitDtoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompensationBenefit(int id)
        {
            var result = await _compesationBenefitService.DeleteCompensationBenefitAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
