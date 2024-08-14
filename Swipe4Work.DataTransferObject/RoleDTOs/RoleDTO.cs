using Swipe4Work.Domain.Models;


namespace Swipe4Work.DataTransferObject
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        //public RoleDTO(Role role)
        //{
        //    RoleId = role.RoleId;
        //    Name = role.Name;
        //    Description = role.Description;
        //}
        //public RoleDTO() { }

    }
}
