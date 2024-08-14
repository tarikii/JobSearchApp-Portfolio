using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnswerDto>> GetAllAnswersAsync()
        {
            var answers = await _answerRepository.GetAllAnswersAsync();
            return _mapper.Map<IEnumerable<AnswerDto>>(answers);
        }

        public async Task<AnswerDto> GetAnswerByIdAsync(int answerId)
        {
            var answer = await _answerRepository.GetAnswerByIdAsync(answerId);
            return answer == null ? null : _mapper.Map<AnswerDto>(answer);
        }

        public async Task<AnswerDto> CreateAnswerAsync(CreateAnswerDto createAnswerDto)
        {
            var answer = _mapper.Map<Answer>(createAnswerDto);
            var createdAnswer = await _answerRepository.CreateAnswerAsync(answer);
            return _mapper.Map<AnswerDto>(createdAnswer);
        }

        public async Task<AnswerDto> UpdateAnswerAsync(int answerId, UpdateAnswerDto updateAnswerDto)
        {
            if (answerId != updateAnswerDto.AnswerId)
            {
                return null;
            }

            var answer = _mapper.Map<Answer>(updateAnswerDto);
            var updatedAnswer = await _answerRepository.UpdateAnswerAsync(answer);
            return _mapper.Map<AnswerDto>(updatedAnswer);
        }

        public async Task<bool> DeleteAnswerAsync(int answerId)
        {
            return await _answerRepository.DeleteAnswerAsync(answerId);
        }
    }
}
