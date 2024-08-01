using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IApplicationService
{
    Task<IEnumerable<ApplicationDto>> GetAllApplicationsAsync();
    Task<ApplicationDto> GetApplicationByIdAsync(int id);
    Task<ApplicationDto> CreateApplicationAsync(ApplicationDto applicationDto);
    Task<bool> UpdateApplicationAsync(ApplicationDto applicationDto);
    Task<bool> DeleteApplicationAsync(int id);
}