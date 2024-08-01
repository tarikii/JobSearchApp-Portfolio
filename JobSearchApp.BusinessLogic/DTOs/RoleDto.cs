using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs;

public class RoleDto
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public RoleDto(Role role)
    {
        RoleId = role.RoleId;
        Name = role.Name;
        Description = role.Description;
    }
}

public class CreateRoleDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class UpdateRoleDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}