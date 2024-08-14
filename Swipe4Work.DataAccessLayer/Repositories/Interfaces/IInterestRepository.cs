using Swipe4Work.Domain.Models;
namespace Swipe4Work.DataAccessLayer.Interfaces
{
    public interface IInterestRepository
    {
        Task<IEnumerable<Interest>> GetAllInterestsAsync();
        Task<Interest> GetInterestByIdAsync(int interestId);
        Task<Interest> CreateInterestAsync(Interest interest);
        Task<Interest> UpdateInterestAsync(Interest interest);
        Task<bool> DeleteInterestAsync(int interestId);
    }
}