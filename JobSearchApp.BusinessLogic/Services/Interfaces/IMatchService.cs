using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IMatchService
{
    Task<IEnumerable<MatchDto>> GetAllMatchesAsync();
    Task<MatchDto> GetMatchByIdAsync(int matchId);
    Task<MatchDto> CreateMatchAsync(CreateMatchDto createMatchDto);
    Task<MatchDto> UpdateMatchAsync(int matchId, UpdateMatchDto updateMatchDto);
    Task<bool> DeleteMatchAsync(int matchId);
}