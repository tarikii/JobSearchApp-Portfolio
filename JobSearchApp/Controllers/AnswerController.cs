using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AnswerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return NotFound();

            var answerDto = _mapper.Map<AnswerDto>(answer);
            return Ok(answerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer(CreateAnswerDto createAnswerDto)
        {
            var answer = _mapper.Map<Answer>(createAnswerDto);
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();

            var answerDto = _mapper.Map<AnswerDto>(answer);
            return CreatedAtAction(nameof(GetAnswer), new { id = answerDto.AnswerId }, answerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(int id, UpdateAnswerDto updateAnswerDto)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return NotFound();

            _mapper.Map(updateAnswerDto, answer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return NotFound();

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
