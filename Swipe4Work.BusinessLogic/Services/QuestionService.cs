using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<QuestionDTO>> GetAllQuestionsAsync()
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();
            return _mapper.Map<IEnumerable<QuestionDTO>>(questions);
        }

        public async Task<QuestionDTO> GetQuestionByIdAsync(int questionId)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(questionId);
            return question == null ? null : _mapper.Map<QuestionDTO>(question);
        }

        public async Task<QuestionDTO> CreateQuestionAsync(CreateQuestionDTO createQuestionDTO)
        {
            var question = _mapper.Map<Question>(createQuestionDTO);
            var createdQuestion = await _questionRepository.CreateQuestionAsync(question);
            return _mapper.Map<QuestionDTO>(createdQuestion);
        }

        public async Task<QuestionDTO> UpdateQuestionAsync(int questionId, UpdateQuestionDTO updateQuestionDTO)
        {
            if (questionId != updateQuestionDTO.QuestionId)
            {
                return null;
            }

            var question = _mapper.Map<Question>(updateQuestionDTO);
            var updatedQuestion = await _questionRepository.UpdateQuestionAsync(question);
            return _mapper.Map<QuestionDTO>(updatedQuestion);
        }

        public async Task<bool> DeleteQuestionAsync(int questionId)
        {
            return await _questionRepository.DeleteQuestionAsync(questionId);
        }
    }
}
