namespace Swipe4Work.Domain.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<CompanyTag>? CompanyTags { get; set; }
    }
}
