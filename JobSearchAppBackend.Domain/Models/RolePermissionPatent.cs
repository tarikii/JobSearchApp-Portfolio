namespace JobSearchApp.Domain.Models;

public class RolePermissionPatent
{
    public int RoleId { get; set; }
    public int ResourceId { get; set; }
    public string Permission { get; set; }
}