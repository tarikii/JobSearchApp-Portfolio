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
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetAllFeedbacks()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
            var feedbackDtos = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);

            return Ok(feedbackDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDto>> GetFeedbackById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            var feedbackDto = _mapper.Map<FeedbackDto>(feedback);
            return Ok(feedbackDto);
        }

        [HttpPost]
        public async Task<ActionResult<FeedbackDto>> CreateFeedback(CreateFeedbackDto createFeedbackDto)
        {
            var createdFeedback = await _feedbackService.CreateFeedbackAsync(createFeedbackDto);

            return CreatedAtAction(nameof(GetFeedbackById), new { id = createdFeedback.FeedbackId }, createdFeedback);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FeedbackDto>> UpdateFeedback(int id, UpdateFeedbackDto updateFeedbackDto)
        {
            if (id != updateFeedbackDto.FeedbackId)
            {
                return BadRequest();
            }

            var updatedFeedback = await _feedbackService.UpdateFeedbackAsync(id, updateFeedbackDto);
            if (updatedFeedback == null)
            {
                return NotFound();
            }

            var feedbackDto = _mapper.Map<FeedbackDto>(updatedFeedback);
            return Ok(feedbackDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFeedback(int id)
        {
            var result = await _feedbackService.DeleteFeedbackAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
