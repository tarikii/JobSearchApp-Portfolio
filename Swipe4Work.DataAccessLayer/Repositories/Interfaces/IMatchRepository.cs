using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataAccessLayer.Interfaces
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Match>> GetAllMatchesAsync();
        Task<Match> GetMatchByIdAsync(int matchId);
        Task<Match> CreateMatchAsync(Match match);
        Task<Match> UpdateMatchAsync(Match match);
        Task<bool> DeleteMatchAsync(int matchId);
    }
}