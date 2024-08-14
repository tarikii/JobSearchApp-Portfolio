using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;

namespace Swipe4Work.BusinessLogic.Services
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

        public async Task<IEnumerable<AnswerDTO>> GetAllAnswersAsync()
        {
            var answers = await _answerRepository.GetAllAnswersAsync();
            return _mapper.Map<IEnumerable<AnswerDTO>>(answers);
        }

        public async Task<AnswerDTO> GetAnswerByIdAsync(int answerId)
        {
            var answer = await _answerRepository.GetAnswerByIdAsync(answerId);
            return answer == null ? null : _mapper.Map<AnswerDTO>(answer);
        }

        public async Task<AnswerDTO> CreateAnswerAsync(CreateAnswerDTO createAnswerDTO)
        {

            var answer = _mapper.Map<Answer>(createAnswerDTO);
            var createdAnswer = await _answerRepository.CreateAnswerAsync(answer);
            return _mapper.Map<AnswerDTO>(createdAnswer);
        }

        public async Task<AnswerDTO> UpdateAnswerAsync(int answerId, UpdateAnswerDTO updateAnswerDTO)
        {
            if (answerId != updateAnswerDTO.AnswerId)
            {
                return null;
            }

            var answer = _mapper.Map<Answer>(updateAnswerDTO);
            var updatedAnswer = await _answerRepository.UpdateAnswerAsync(answer);
            return _mapper.Map<AnswerDTO>(updatedAnswer);
        }

        public async Task<bool> DeleteAnswerAsync(int answerId)
        {
            return await _answerRepository.DeleteAnswerAsync(answerId);
        }
    }
}
