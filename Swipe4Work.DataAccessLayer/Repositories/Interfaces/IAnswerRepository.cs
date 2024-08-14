using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataAccessLayer.Interfaces
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