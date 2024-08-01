using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces
{
    public interface IAnswerService
    {
        Task<IEnumerable<AnswerDto>> GetAllAnswersAsync();
        Task<AnswerDto> GetAnswerByIdAsync(int id);
        Task<AnswerDto> CreateAnswerAsync(AnswerDto answerDto);
        Task<bool> UpdateAnswerAsync(AnswerDto answerDto);
        Task<bool> DeleteAnswerAsync(int id);
    }
}