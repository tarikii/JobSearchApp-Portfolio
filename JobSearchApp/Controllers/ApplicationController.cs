using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ApplicationController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null) return NotFound();

            var applicationDto = _mapper.Map<ApplicationDto>(application);
            return Ok(applicationDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(CreateApplicationDto createApplicationDto)
        {
            var application = _mapper.Map<Application>(createApplicationDto);
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            var applicationDto = _mapper.Map<ApplicationDto>(application);
            return CreatedAtAction(nameof(GetApplication), new { id = applicationDto.ApplicationId }, applicationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(int id, UpdateApplicationDto updateApplicationDto)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null) return NotFound();

            _mapper.Map(updateApplicationDto, application);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null) return NotFound();

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
