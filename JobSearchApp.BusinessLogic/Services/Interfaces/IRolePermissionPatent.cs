using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IRolePermissionPatentService
{
    Task<IEnumerable<RolePermissionPatentDto>> GetAllRolePermissionPatentsAsync();
    Task<RolePermissionPatentDto> GetRolePermissionPatentByIdAsync(int roleId, int resourceId, string permission);

    Task<RolePermissionPatentDto> CreateRolePermissionPatentAsync(
        CreateRolePermissionPatentDto createRolePermissionPatentDto);

    Task<RolePermissionPatentDto> UpdateRolePermissionPatentAsync(int roleId, int resourceId, string permission,
        UpdateRolePermissionPatentDto updateRolePermissionPatentDto);

    Task<bool> DeleteRolePermissionPatentAsync(int roleId, int resourceId, string permission);
}