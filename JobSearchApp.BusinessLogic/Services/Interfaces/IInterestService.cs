using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IInterestService
{
    Task<IEnumerable<InterestDto>> GetAllInterestsAsync();
    Task<InterestDto> GetInterestByIdAsync(int interestId);
    Task<InterestDto> CreateInterestAsync(CreateInterestDto createInterestDto, int userId);
    Task<InterestDto> UpdateInterestAsync(int interestId, UpdateInterestDto updateInterestDto);
    Task<bool> DeleteInterestAsync(int interestId);
}