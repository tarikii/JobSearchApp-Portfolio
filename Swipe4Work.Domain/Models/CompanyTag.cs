namespace Swipe4Work.Domain.Models
{
    public class CompanyTag
    {
        public int CompanyId { get; set; }
        public int TagId { get; set; }

        public Company? Company { get; set; }
        public Tag? Tag { get; set; }
    }
}
