using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IResourceService
{
    Task<IEnumerable<ResourceDto>> GetAllResourcesAsync();
    Task<ResourceDto> GetResourceByIdAsync(int id);
    Task<ResourceDto> CreateResourceAsync(ResourceDto resourceDto);
    Task<bool> UpdateResourceAsync(ResourceDto resourceDto);
    Task<bool> DeleteResourceAsync(int id);
}