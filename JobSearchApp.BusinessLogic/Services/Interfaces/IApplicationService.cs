using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IApplicationService
{
    Task<IEnumerable<ApplicationDto>> GetAllApplicationsAsync();
    Task<ApplicationDto> GetApplicationByIdAsync(int applicationId);
    Task<ApplicationDto> CreateApplicationAsync(CreateApplicationDto createApplicationDto);
    Task<ApplicationDto> UpdateApplicationAsync(int applicationId, UpdateApplicationDto updateApplicationDto);
    Task<bool> DeleteApplicationAsync(int applicationId);
}