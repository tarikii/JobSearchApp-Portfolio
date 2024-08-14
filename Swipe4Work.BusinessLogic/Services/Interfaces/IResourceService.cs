using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IResourceService
{
    Task<IEnumerable<ResourceDTO>> GetAllResourcesAsync();
    Task<ResourceDTO> GetResourceByIdAsync(int resourceId);
    Task<ResourceDTO> CreateResourceAsync(CreateResourceDTO createResourceDTO);
    Task<ResourceDTO> UpdateResourceAsync(int resourceId, UpdateResourceDTO updateResourceDTO);
    Task<bool> DeleteResourceAsync(int resourceId);
}   