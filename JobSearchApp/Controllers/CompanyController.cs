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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return Ok(companyDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> CreateCompany(CreateCompanyDto createCompanyDto)
        {
            var createdCompany = await _companyService.CreateCompanyAsync(createCompanyDto);

            return CreatedAtAction(nameof(GetCompanyById), new { id = createdCompany.CompanyId }, createdCompany);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyDto>> UpdateCompany(int id, UpdateCompanyDto updateCompanyDto)
        {
            if (id != updateCompanyDto.CompanyId)
            {
                return BadRequest();
            }

            var updatedCompany = await _companyService.UpdateCompanyAsync(id, updateCompanyDto);
            if (updatedCompany == null)
            {
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyDto>(updatedCompany);
            return Ok(companyDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var result = await _companyService.DeleteCompanyAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
