using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs;

public class ResourceDto
{
    public int ResourceId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public ResourceDto(Resource resource)
    {
        ResourceId = resource.ResourceId;
        Name = resource.Name;
        Description = resource.Description;
    }
}

public class CreateResourceDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class UpdateResourceDto
{
    public int ResourceId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}