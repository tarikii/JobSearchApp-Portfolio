using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IFeedbackService
{
    Task<IEnumerable<FeedbackDTO>> GetAllFeedbacksAsync();
    Task<FeedbackDTO> GetFeedbackByIdAsync(int feedbackId);
    Task<FeedbackDTO> CreateFeedbackAsync(CreateFeedbackDTO createFeedbackDTO);
    Task<FeedbackDTO> UpdateFeedbackAsync(int feedbackId, UpdateFeedbackDTO updateFeedbackDTO);
    Task<bool> DeleteFeedbackAsync(int feedbackId);
}