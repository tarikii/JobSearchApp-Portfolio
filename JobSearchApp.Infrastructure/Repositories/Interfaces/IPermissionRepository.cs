using System.Collections.Generic;
using System.Threading.Tasks;
using JobSearchApp.Domain.Models;

namespace JobSearchApp.Infrastructure.Interfaces
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(string name);
        Task<Permission> CreatePermissionAsync(Permission permission);
        Task<Permission> UpdatePermissionAsync(Permission permission);
        Task<bool> DeletePermissionAsync(string name);
    }
}