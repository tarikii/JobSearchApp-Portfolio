using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IQuestionService
{
    Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
    Task<QuestionDto> GetQuestionByIdAsync(int questionId);
    Task<QuestionDto> CreateQuestionAsync(CreateQuestionDto createQuestionDto);
    Task<QuestionDto> UpdateQuestionAsync(int questionId, UpdateQuestionDto updateQuestionDto);
    Task<bool> DeleteQuestionAsync(int questionId);
}