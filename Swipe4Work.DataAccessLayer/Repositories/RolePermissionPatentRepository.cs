using Microsoft.EntityFrameworkCore;
using Swipe4Work.DataAccessLayer.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.Infrastructure.Data;

namespace Swipe4Work.DataAccessLayer
{
    public class RolePermissionPatentRepository : IRolePermissionPatentRepository
    {
        private readonly ApplicationDbContext _context;

        public RolePermissionPatentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RolePermissionPatent>> GetAllRolePermissionPatentsAsync()
        {
            return await _context.RolePermissionPatents.ToListAsync();
        }

        public async Task<RolePermissionPatent> GetRolePermissionPatentByIdAsync(int roleId, int resourceId, string permission)
        {
            return await _context.RolePermissionPatents
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.ResourceId == resourceId && rp.Permission == permission);
        }

        public async Task<RolePermissionPatent> CreateRolePermissionPatentAsync(RolePermissionPatent rolePermissionPatent)
        {
            _context.RolePermissionPatents.Add(rolePermissionPatent);
            await _context.SaveChangesAsync();
            return rolePermissionPatent;
        }

        public async Task<RolePermissionPatent> UpdateRolePermissionPatentAsync(RolePermissionPatent rolePermissionPatent)
        {
            _context.RolePermissionPatents.Update(rolePermissionPatent);
            await _context.SaveChangesAsync();
            return rolePermissionPatent;
        }

        public async Task<bool> DeleteRolePermissionPatentAsync(int roleId, int resourceId, string permission)
        {
            var rolePermissionPatent = await _context.RolePermissionPatents
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.ResourceId == resourceId && rp.Permission == permission);
            if (rolePermissionPatent == null)
            {
                return false;
            }

            _context.RolePermissionPatents.Remove(rolePermissionPatent);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
