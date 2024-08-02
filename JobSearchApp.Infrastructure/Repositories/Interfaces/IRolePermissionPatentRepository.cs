using JobSearchApp.Domain.Models;

namespace JobSearchApp.Infrastructure.Interfaces;

public interface IRolePermissionPatentRepository
{
    Task<IEnumerable<RolePermissionPatent>> GetAllRolePermissionPatentsAsync();
    Task<RolePermissionPatent> GetRolePermissionPatentByIdAsync(int roleId, int resourceId, string permission);
    Task<RolePermissionPatent> CreateRolePermissionPatentAsync(RolePermissionPatent rolePermissionPatent);
    Task<RolePermissionPatent> UpdateRolePermissionPatentAsync(RolePermissionPatent rolePermissionPatent);
    Task<bool> DeleteRolePermissionPatentAsync(int roleId, int resourceId, string permission);
}