using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IMatchService
{
    Task<IEnumerable<MatchDTO>> GetAllMatchesAsync();
    Task<MatchDTO> GetMatchByIdAsync(int matchId);
    Task<MatchDTO> CreateMatchAsync(CreateMatchDTO createMatchDTO);
    Task<MatchDTO> UpdateMatchAsync(int matchId, UpdateMatchDTO updateMatchDTO);
    Task<bool> DeleteMatchAsync(int matchId);
}