using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IInterestService
{
    Task<IEnumerable<InterestDTO>> GetAllInterestsAsync();
    Task<InterestDTO> GetInterestByIdAsync(int interestId);
    Task<InterestDTO> CreateInterestAsync(CreateInterestDTO createInterestDTO);
    Task<InterestDTO> UpdateInterestAsync(int interestId, UpdateInterestDTO updateInterestDTO);
    Task<bool> DeleteInterestAsync(int interestId);
}
