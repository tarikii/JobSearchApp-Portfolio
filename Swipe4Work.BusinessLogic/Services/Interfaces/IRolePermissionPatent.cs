using Swipe4Work.DataTransferObject;

namespace Swipe4Work.BusinessLogic.Interfaces;

public interface IRolePermissionPatentService
{
    Task<IEnumerable<RolePermissionPatentDTO>> GetAllRolePermissionPatentsAsync();
    Task<RolePermissionPatentDTO> GetRolePermissionPatentByIdAsync(int roleId, int resourceId, string permission);

    Task<RolePermissionPatentDTO> CreateRolePermissionPatentAsync(
        CreateRolePermissionPatentDTO createRolePermissionPatentDTO);

    Task<RolePermissionPatentDTO> UpdateRolePermissionPatentAsync(int roleId, int resourceId, string permission,
        UpdateRolePermissionPatentDTO updateRolePermissionPatentDTO);

    Task<bool> DeleteRolePermissionPatentAsync(int roleId, int resourceId, string permission);
}