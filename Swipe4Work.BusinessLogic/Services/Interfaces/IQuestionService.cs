using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IQuestionService
{
    Task<IEnumerable<QuestionDTO>> GetAllQuestionsAsync();
    Task<QuestionDTO> GetQuestionByIdAsync(int questionId);
    Task<QuestionDTO> CreateQuestionAsync(CreateQuestionDTO createQuestionDTO);
    Task<QuestionDTO> UpdateQuestionAsync(int questionId, UpdateQuestionDTO updateQuestionDTO);
    Task<bool> DeleteQuestionAsync(int questionId);
}