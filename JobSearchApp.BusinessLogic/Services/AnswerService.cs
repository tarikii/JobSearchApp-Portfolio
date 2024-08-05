using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.BusinessLogic.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AnswerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnswerDto>> GetAllAnswersAsync()
        {
            var answers = await _context.Answers.ToListAsync();
            return _mapper.Map<IEnumerable<AnswerDto>>(answers);
        }

        public async Task<AnswerDto> GetAnswerByIdAsync(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);
            return answer == null ? null : _mapper.Map<AnswerDto>(answer);
        }

        public async Task<AnswerDto> CreateAnswerAsync(CreateAnswerDto createAnswerDto)
        {
            var answer = _mapper.Map<Answer>(createAnswerDto);
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return _mapper.Map<AnswerDto>(answer);
        }

        public async Task<AnswerDto> UpdateAnswerAsync(int answerId, UpdateAnswerDto updateAnswerDto)
        {
            if (answerId != updateAnswerDto.AnswerId)
            {
                return null;
            }

            var answer = _mapper.Map<Answer>(updateAnswerDto);
            _context.Answers.Update(answer);
            await _context.SaveChangesAsync();
            return _mapper.Map<AnswerDto>(answer);
        }

        public async Task<bool> DeleteAnswerAsync(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);
            if (answer == null)
            {
                return false;
            }

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
