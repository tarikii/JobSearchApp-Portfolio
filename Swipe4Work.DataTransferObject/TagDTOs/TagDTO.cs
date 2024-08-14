using Swipe4Work.Domain.Models;


namespace Swipe4Work.DataTransferObject
{
    public class TagDTO
    {
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public string? ImageUrl { get; set; }

        //public TagDTO(Tag tag)
        //{
        //    TagId = tag.TagId;
        //    TagName = tag.TagName;
        //    ImageUrl = tag.ImageUrl;
        //}
        //public TagDTO() { }

    }
}
