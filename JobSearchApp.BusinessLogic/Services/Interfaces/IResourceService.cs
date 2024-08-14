using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IResourceService
{
    Task<IEnumerable<ResourceDto>> GetAllResourcesAsync();
    Task<ResourceDto> GetResourceByIdAsync(int resourceId);
    Task<ResourceDto> CreateResourceAsync(CreateResourceDto createResourceDto);
    Task<ResourceDto> UpdateResourceAsync(int resourceId, UpdateResourceDto updateResourceDto);
    Task<bool> DeleteResourceAsync(int resourceId);
}   