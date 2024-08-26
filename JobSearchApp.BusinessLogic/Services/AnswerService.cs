using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Services.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;
using JobSearchApp.Infrastructure.Repositories;

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

        public async Task<AnswerDto> CreateAnswerAsync(CreateAnswerDto createAnswerDto, int userId)
        {
            CreateAnswerDto newAnswer = createAnswerDto;
            newAnswer.UserId = userId;

            var answer = _mapper.Map<Answer>(createAnswerDto);
            var createdAnswer = await _answerRepository.CreateAnswerAsync(answer);
            return _mapper.Map<AnswerDto>(createdAnswer);
        }

        public async Task<AnswerDto> UpdateAnswerAsync(int answerId, UpdateAnswerDto updateAnswerDto)
        {
            var existingAnswer = await _answerRepository.GetAnswerByIdAsync(answerId);
            if (existingAnswer == null)
            {
                // Handle the case where the interest does not exist
                throw new Exception($"Answer with ID {answerId} not found.");
            }

            // Update properties on the existing interest
            _mapper.Map(updateAnswerDto, existingAnswer);

            var updatedAnswer = await _answerRepository.UpdateAnswerAsync(existingAnswer);
            return _mapper.Map<AnswerDto>(updatedAnswer);
        }

        public async Task<bool> DeleteAnswerAsync(int answerId)
        {
            return await _answerRepository.DeleteAnswerAsync(answerId);
        }
    }
}
