using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IFeedbackService
{
    Task<IEnumerable<FeedbackDto>> GetAllFeedbacksAsync();
    Task<FeedbackDto> GetFeedbackByIdAsync(int id);
    Task<FeedbackDto> CreateFeedbackAsync(FeedbackDto feedbackDto);
    Task<bool> UpdateFeedbackAsync(FeedbackDto feedbackDto);
    Task<bool> DeleteFeedbackAsync(int id);
}