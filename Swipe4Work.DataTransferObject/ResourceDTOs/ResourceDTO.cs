using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject
{
    public class ResourceDTO
    {
        public int ResourceId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        //public ResourceDTO(Resource resource)
        //{
        //    ResourceId = resource.ResourceId;
        //    Name = resource.Name;
        //    Description = resource.Description;
        //}
        //public ResourceDTO() { }

    }
}
