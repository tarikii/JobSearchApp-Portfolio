using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs;

public class RolePermissionPatentDto
{
    public int RoleId { get; set; }
    public int ResourceId { get; set; }
    public string Permission { get; set; }

    public string RoleName { get; set; }
    public string ResourceName { get; set; }

    public RolePermissionPatentDto(RolePermissionPatent rolePermissionPatent)
    {
        RoleId = rolePermissionPatent.RoleId;
        ResourceId = rolePermissionPatent.ResourceId;
        Permission = rolePermissionPatent.Permission;
        RoleName = rolePermissionPatent.Role?.Name;
        ResourceName = rolePermissionPatent.Resource?.Name;
    }
    public RolePermissionPatentDto(){}

}

public class CreateRolePermissionPatentDto
{
    public int RoleId { get; set; }
    public int ResourceId { get; set; }
    public string Permission { get; set; }
}

public class UpdateRolePermissionPatentDto
{
    public int RoleId { get; set; }
    public int ResourceId { get; set; }
    public string Permission { get; set; }
}