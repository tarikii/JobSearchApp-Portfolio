using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;

namespace JobSearchApp.BusinessLogic.Services
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

        public async Task<IEnumerable<FeedbackDto>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _feedbackRepository.GetAllFeedbacksAsync();
            return _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        }

        public async Task<FeedbackDto> GetFeedbackByIdAsync(int feedbackId)
        {
            var feedback = await _feedbackRepository.GetFeedbackByIdAsync(feedbackId);
            return feedback == null ? null : _mapper.Map<FeedbackDto>(feedback);
        }

        public async Task<FeedbackDto> CreateFeedbackAsync(CreateFeedbackDto createFeedbackDto)
        {
            var feedback = _mapper.Map<Feedback>(createFeedbackDto);
            var createdFeedback = await _feedbackRepository.CreateFeedbackAsync(feedback);
            return _mapper.Map<FeedbackDto>(createdFeedback);
        }

        public async Task<FeedbackDto> UpdateFeedbackAsync(int feedbackId, UpdateFeedbackDto updateFeedbackDto)
        {
            if (feedbackId != updateFeedbackDto.FeedbackId)
            {
                return null;
            }

            var feedback = _mapper.Map<Feedback>(updateFeedbackDto);
            var updatedFeedback = await _feedbackRepository.UpdateFeedbackAsync(feedback);
            return _mapper.Map<FeedbackDto>(updatedFeedback);
        }

        public async Task<bool> DeleteFeedbackAsync(int feedbackId)
        {
            return await _feedbackRepository.DeleteFeedbackAsync(feedbackId);
        }
    }
}
