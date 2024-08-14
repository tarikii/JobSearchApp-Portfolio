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
    public class CompanyTagController : ControllerBase
    {
        private readonly ICompanyTagService _companyTagService;
        private readonly IMapper _mapper;

        public CompanyTagController(ICompanyTagService companyTagService, IMapper mapper)
        {
            _companyTagService = companyTagService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyTagDto>>> GetAllCompanies()
        {
            var companies = await _companyTagService.GetAllCompanyTagsAsync();
            var companyDtos = _mapper.Map<IEnumerable<CompanyTagDto>>(companies);

            return Ok(companyDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyTagDto>> GetCompanyById(int id)
        {
            var company = await _companyTagService.GetCompanyTagByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            var companyDto = _mapper.Map<CompanyTagDto>(company);
            return Ok(companyDto);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyTagDto>> CreateCompanyTag(CreateCompanyTagDto createCompanyTagDto)
        {
            var createdCompany = await _companyTagService.CreateCompanyTagAsync(createCompanyTagDto);

            return CreatedAtAction(nameof(GetCompanyById), new { id = createdCompany.CompanyId }, createdCompany);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyTagDto>> UpdateCompanyTag(int id, UpdateCompanyTagDto updateCompanyTagDto)
        {
            if (id != updateCompanyTagDto.CompanyTagId)
            {
                return BadRequest();
            }

            var updatedCompany = await _companyTagService.UpdateCompanyTagAsync(id, updateCompanyTagDto);
            if (updatedCompany == null)
            {
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyTagDto>(updatedCompany);
            return Ok(companyDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var result = await _companyTagService.DeleteCompanyTagAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
