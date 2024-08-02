using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOfferController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public JobOfferController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobOffer(int id)
        {
            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer == null) return NotFound();

            var jobOfferDto = _mapper.Map<JobOfferDto>(jobOffer);
            return Ok(jobOfferDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobOffer(CreateJobOfferDto createJobOfferDto)
        {
            var jobOffer = _mapper.Map<JobOffer>(createJobOfferDto);
            _context.JobOffers.Add(jobOffer);
            await _context.SaveChangesAsync();

            var jobOfferDto = _mapper.Map<JobOfferDto>(jobOffer);
            return CreatedAtAction(nameof(GetJobOffer), new { id = jobOfferDto.JobOfferId }, jobOfferDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobOffer(int id, UpdateJobOfferDto updateJobOfferDto)
        {
            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer == null) return NotFound();

            _mapper.Map(updateJobOfferDto, jobOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobOffer(int id)
        {
            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer == null) return NotFound();

            _context.JobOffers.Remove(jobOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
