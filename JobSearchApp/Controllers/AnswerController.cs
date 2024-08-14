using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;

        public AnswerController(IAnswerService answerService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerDto>>> GetAllAnswers()
        {
            var answers = await _answerService.GetAllAnswersAsync();
            var answerDtos = _mapper.Map<IEnumerable<AnswerDto>>(answers);

            return Ok(answerDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerDto>> GetAnswerById(int id)
        {
            var answer = await _answerService.GetAnswerByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            var answerDto = _mapper.Map<AnswerDto>(answer);
            return Ok(answerDto);
        }

        [HttpPost]
        public async Task<ActionResult<AnswerDto>> CreateAnswer(CreateAnswerDto createAnswerDto)
        {
            var createdAnswer = await _answerService.CreateAnswerAsync(createAnswerDto);
            var answerDto = _mapper.Map<AnswerDto>(createdAnswer);

            return CreatedAtAction(nameof(GetAnswerById), new { id = answerDto.AnswerId }, answerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AnswerDto>> UpdateAnswer(int id, UpdateAnswerDto updateAnswerDto)
        {
            if (id != updateAnswerDto.AnswerId)
            {
                return BadRequest();
            }

            var updatedAnswer = await _answerService.UpdateAnswerAsync(id, updateAnswerDto);
            if (updatedAnswer == null)
            {
                return NotFound();
            }

            var answerDto = _mapper.Map<AnswerDto>(updatedAnswer);
            return Ok(answerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnswer(int id)
        {
            var result = await _answerService.DeleteAnswerAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
