using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject
{
    public class RolePermissionPatentDTO
    {
        public int RoleId { get; set; }
        public int ResourceId { get; set; }
        public string? Permission { get; set; }

        public string? RoleName { get; set; }
        public string? ResourceName { get; set; }

        //public RolePermissionPatentDTO(RolePermissionPatent rolePermissionPatent)
        //{
        //    RoleId = rolePermissionPatent.RoleId;
        //    ResourceId = rolePermissionPatent.ResourceId;
        //    Permission = rolePermissionPatent.Permission;
        //    RoleName = rolePermissionPatent.Role?.Name;
        //    ResourceName = rolePermissionPatent.Resource?.Name;
        //}
        //public RolePermissionPatentDTO() { }

    }
}
