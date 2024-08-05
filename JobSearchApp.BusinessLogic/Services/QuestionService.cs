using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync()
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();
            return _mapper.Map<IEnumerable<QuestionDto>>(questions);
        }

        public async Task<QuestionDto> GetQuestionByIdAsync(int questionId)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(questionId);
            return question == null ? null : _mapper.Map<QuestionDto>(question);
        }

        public async Task<QuestionDto> CreateQuestionAsync(CreateQuestionDto createQuestionDto)
        {
            var question = _mapper.Map<Question>(createQuestionDto);
            var createdQuestion = await _questionRepository.CreateQuestionAsync(question);
            return _mapper.Map<QuestionDto>(createdQuestion);
        }

        public async Task<QuestionDto> UpdateQuestionAsync(int questionId, UpdateQuestionDto updateQuestionDto)
        {
            if (questionId != updateQuestionDto.QuestionId)
            {
                return null;
            }

            var question = _mapper.Map<Question>(updateQuestionDto);
            var updatedQuestion = await _questionRepository.UpdateQuestionAsync(question);
            return _mapper.Map<QuestionDto>(updatedQuestion);
        }

        public async Task<bool> DeleteQuestionAsync(int questionId)
        {
            return await _questionRepository.DeleteQuestionAsync(questionId);
        }
    }
}
