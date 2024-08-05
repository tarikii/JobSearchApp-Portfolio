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
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferService _jobOfferService;
        private readonly IMapper _mapper;

        public JobOfferController(IJobOfferService jobOfferService, IMapper mapper)
        {
            _jobOfferService = jobOfferService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOfferDto>>> GetAllJobOffers()
        {
            var jobOffers = await _jobOfferService.GetAllJobOffersAsync();
            var jobOfferDtos = _mapper.Map<IEnumerable<JobOfferDto>>(jobOffers);

            return Ok(jobOfferDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobOfferDto>> GetJobOfferById(int id)
        {
            var jobOffer = await _jobOfferService.GetJobOfferByIdAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            var jobOfferDto = _mapper.Map<JobOfferDto>(jobOffer);
            return Ok(jobOfferDto);
        }

        [HttpPost]
        public async Task<ActionResult<JobOfferDto>> CreateJobOffer(CreateJobOfferDto createJobOfferDto)
        {
            var jobOffer = _mapper.Map<JobOffer>(createJobOfferDto);
            var createdJobOffer = await _jobOfferService.CreateJobOfferAsync(jobOffer);
            var jobOfferDto = _mapper.Map<JobOfferDto>(createdJobOffer);

            return CreatedAtAction(nameof(GetJobOfferById), new { id = jobOfferDto.JobOfferId }, jobOfferDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JobOfferDto>> UpdateJobOffer(int id, UpdateJobOfferDto updateJobOfferDto)
        {
            if (id != updateJobOfferDto.JobOfferId)
            {
                return BadRequest();
            }

            var updatedJobOffer = await _jobOfferService.UpdateJobOfferAsync(id, updateJobOfferDto);
            if (updatedJobOffer == null)
            {
                return NotFound();
            }

            var jobOfferDto = _mapper.Map<JobOfferDto>(updatedJobOffer);
            return Ok(jobOfferDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJobOffer(int id)
        {
            var result = await _jobOfferService.DeleteJobOfferAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
