using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IApplicationService
{
    Task<IEnumerable<ApplicationDTO>> GetAllApplicationsAsync();
    Task<ApplicationDTO> GetApplicationByIdAsync(int applicationId);
    Task<ApplicationDTO> CreateApplicationAsync(CreateApplicationDTO createApplicationDTO);
    Task<ApplicationDTO> UpdateApplicationAsync(int applicationId, UpdateApplicationDTO updateApplicationDTO);
    Task<bool> DeleteApplicationAsync(int applicationId);
}