using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Services.Interfaces;

public interface IAnswerService
{
    Task<IEnumerable<AnswerDto>> GetAllAnswersAsync();
    Task<AnswerDto> GetAnswerByIdAsync(int answerId);
    Task<AnswerDto> CreateAnswerAsync(CreateAnswerDto createAnswerDto, int userId);
    Task<AnswerDto> UpdateAnswerAsync(int answerId, UpdateAnswerDto updateAnswerDto);
    Task<bool> DeleteAnswerAsync(int answerId);
}