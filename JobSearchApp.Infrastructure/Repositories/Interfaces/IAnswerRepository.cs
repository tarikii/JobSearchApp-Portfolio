using JobSearchApp.Domain.Models;

namespace JobSearchApp.Infrastructure.Interfaces
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetAllAnswersAsync();
        Task<Answer> GetAnswerByIdAsync(int answerId);
        Task<Answer> CreateAnswerAsync(Answer answer);
        Task<Answer> UpdateAnswerAsync(Answer answer);
        Task<bool> DeleteAnswerAsync(int answerId);
    }
}