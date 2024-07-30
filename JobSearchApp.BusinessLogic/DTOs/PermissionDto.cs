using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class PermissionDto
    {
        public string Name { get; set; }

        public PermissionDto(Permission permission)
        {
            Name = permission.Name;
        }
    }
}