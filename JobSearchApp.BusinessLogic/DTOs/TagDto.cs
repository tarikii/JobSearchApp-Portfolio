using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class TagDto
    {
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public string? ImageUrl { get; set; }

        public TagDto(Tag tag)
        {
            TagId = tag.TagId;
            TagName = tag.TagName;
            ImageUrl = tag.ImageUrl;
        }
    }
    public class CreateTagDto
    {
        public string? TagName { get; set; }
        public string? ImageUrl { get; set; }
    }
    
    public class UpdateTagDto
    {
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public string? ImageUrl { get; set; }
    }
}