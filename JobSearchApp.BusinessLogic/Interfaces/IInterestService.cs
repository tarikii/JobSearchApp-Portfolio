using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IInterestService
{
    Task<IEnumerable<InterestDto>> GetAllInterestsAsync();
    Task<InterestDto> GetInterestByIdAsync(int id);
    Task<InterestDto> CreateInterestAsync(InterestDto interestDto);
    Task<bool> UpdateInterestAsync(InterestDto interestDto);
    Task<bool> DeleteInterestAsync(int id);
}