using JobSearchApp.BusinessLogic.DTOs;

namespace JobSearchApp.BusinessLogic.Interfaces;
    public interface IRolePermissionPatentService
    {
        Task<IEnumerable<RolePermissionPatentDto>> GetAllRolePermissionPatentsAsync();
        Task<RolePermissionPatentDto> GetRolePermissionPatentByIdAsync(int roleId, int resourceId, string permission);
        Task<RolePermissionPatentDto> CreateRolePermissionPatentAsync(RolePermissionPatentDto rolePermissionPatentDto);
        Task<bool> UpdateRolePermissionPatentAsync(RolePermissionPatentDto rolePermissionPatentDto);
        Task<bool> DeleteRolePermissionPatentAsync(int roleId, int resourceId, string permission);
    }
