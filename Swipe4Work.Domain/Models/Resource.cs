namespace Swipe4Work.Domain.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<RolePermissionPatent>? RolePermissionPatents { get; set; }
    }
}
