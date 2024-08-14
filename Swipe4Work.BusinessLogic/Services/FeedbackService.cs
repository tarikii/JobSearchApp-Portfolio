using AutoMapper;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.DataTransferObject;
using Swipe4Work.Domain.Models;
namespace Swipe4Work.BusinessLogic.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackDTO>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _feedbackRepository.GetAllFeedbacksAsync();
            return _mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks);
        }

        public async Task<FeedbackDTO> GetFeedbackByIdAsync(int feedbackId)
        {
            var feedback = await _feedbackRepository.GetFeedbackByIdAsync(feedbackId);
            return feedback == null ? null : _mapper.Map<FeedbackDTO>(feedback);
        }

        public async Task<FeedbackDTO> CreateFeedbackAsync(CreateFeedbackDTO createFeedbackDTO)
        {
            var feedback = _mapper.Map<Feedback>(createFeedbackDTO);
            var createdFeedback = await _feedbackRepository.CreateFeedbackAsync(feedback);
            return _mapper.Map<FeedbackDTO>(createdFeedback);
        }

        public async Task<FeedbackDTO> UpdateFeedbackAsync(int feedbackId, UpdateFeedbackDTO updateFeedbackDTO)
        {
            if (feedbackId != updateFeedbackDTO.FeedbackId)
            {
                return null;
            }

            var feedback = _mapper.Map<Feedback>(updateFeedbackDTO);
            var updatedFeedback = await _feedbackRepository.UpdateFeedbackAsync(feedback);
            return _mapper.Map<FeedbackDTO>(updatedFeedback);
        }

        public async Task<bool> DeleteFeedbackAsync(int feedbackId)
        {
            return await _feedbackRepository.DeleteFeedbackAsync(feedbackId);
        }
    }
}
