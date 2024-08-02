using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;

public interface IPermissionService
{
    Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync();
    Task<PermissionDto> GetPermissionByIdAsync(string name);
    Task<PermissionDto> CreatePermissionAsync(CreatePermissionDto createPermissionDto);
    Task<PermissionDto> UpdatePermissionAsync(string name, UpdatePermissionDto updatePermissionDto);
    Task<bool> DeletePermissionAsync(string name);
}