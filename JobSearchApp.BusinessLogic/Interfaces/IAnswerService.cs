using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces
{
    public interface IAnswerService
    {
        Task<IEnumerable<AnswerDto>> GetAllAnswersAsync();
        Task<AnswerDto> GetAnswerByIdAsync(int id);
        Task<AnswerDto> CreateAnswerAsync(CreateAnswerDto answerDto);
        Task<bool> UpdateAnswerAsync(UpdateAnswerDto answerDto);
        Task<bool> DeleteAnswerAsync(int id);
    }
}