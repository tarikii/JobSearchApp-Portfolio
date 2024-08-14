namespace Swipe4Work.Domain.Models
{
    public class RolePermissionPatent
    {
        public int RoleId { get; set; }
        public int ResourceId { get; set; }
        public string? Permission { get; set; }

        public Role? Role { get; set; }
        public Resource? Resource { get; set; }
        public Permission? PermissionEntity { get; set; }
    }
}
