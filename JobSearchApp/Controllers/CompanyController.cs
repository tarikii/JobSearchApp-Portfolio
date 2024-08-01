using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CompanyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return NotFound();

            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyDto createCompanyDto)
        {
            var company = _mapper.Map<Company>(createCompanyDto);
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            var companyDto = _mapper.Map<CompanyDto>(company);
            return CreatedAtAction(nameof(GetCompany), new { id = companyDto.CompanyId }, companyDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, UpdateCompanyDto updateCompanyDto)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return NotFound();

            _mapper.Map(updateCompanyDto, company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return NotFound();

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
