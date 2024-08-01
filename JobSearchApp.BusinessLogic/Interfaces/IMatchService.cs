using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IMatchService
{
    Task<IEnumerable<MatchDto>> GetAllMatchesAsync();
    Task<MatchDto> GetMatchByIdAsync(int id);
    Task<MatchDto> CreateMatchAsync(MatchDto matchDto);
    Task<bool> UpdateMatchAsync(MatchDto matchDto);
    Task<bool> DeleteMatchAsync(int id);
}