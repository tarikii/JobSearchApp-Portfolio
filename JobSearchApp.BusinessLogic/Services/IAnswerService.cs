using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IAnswerService
{
    Task<IEnumerable<AnswerDto>> GetAllAnswersAsync();
    Task<AnswerDto> GetAnswerByIdAsync(int answerId);
    Task<AnswerDto> CreateAnswerAsync(CreateAnswerDto createAnswerDto);
    Task<AnswerDto> UpdateAnswerAsync(int answerId, UpdateAnswerDto updateAnswerDto);
    Task<bool> DeleteAnswerAsync(int answerId);
}