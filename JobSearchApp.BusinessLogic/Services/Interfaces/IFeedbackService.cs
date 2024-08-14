using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IFeedbackService
{
    Task<IEnumerable<FeedbackDto>> GetAllFeedbacksAsync();
    Task<FeedbackDto> GetFeedbackByIdAsync(int feedbackId);
    Task<FeedbackDto> CreateFeedbackAsync(CreateFeedbackDto createFeedbackDto);
    Task<FeedbackDto> UpdateFeedbackAsync(int feedbackId, UpdateFeedbackDto updateFeedbackDto);
    Task<bool> DeleteFeedbackAsync(int feedbackId);
}