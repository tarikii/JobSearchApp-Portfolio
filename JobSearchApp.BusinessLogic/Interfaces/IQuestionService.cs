using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IQuestionService
{
    Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
    Task<QuestionDto> GetQuestionByIdAsync(int id);
    Task<QuestionDto> CreateQuestionAsync(QuestionDto questionDto);
    Task<bool> UpdateQuestionAsync(QuestionDto questionDto);
    Task<bool> DeleteQuestionAsync(int id);
}