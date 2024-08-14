using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IPermissionService
{
    Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync();
    Task<PermissionDTO> GetPermissionByNameAsync(string name);
    Task<PermissionDTO> CreatePermissionAsync(CreatePermissionDTO createPermissionDTO);
    Task<PermissionDTO> UpdatePermissionAsync(string name, UpdatePermissionDTO updatePermissionDTO);
    Task<bool> DeletePermissionAsync(string name);
}