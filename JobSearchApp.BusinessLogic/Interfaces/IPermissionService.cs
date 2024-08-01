using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IPermissionService
{
    Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync();
    Task<PermissionDto> GetPermissionByNameAsync(string name);
    Task<PermissionDto> CreatePermissionAsync(PermissionDto permissionDto);
    Task<bool> UpdatePermissionAsync(PermissionDto permissionDto);
    Task<bool> DeletePermissionAsync(string name);
}