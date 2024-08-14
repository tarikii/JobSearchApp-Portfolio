namespace Swipe4Work.Domain.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Industry { get; set; }
        public string? Size { get; set; }
        public string? Headquarters { get; set; }
        public int FoundedYear { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }

        public ICollection<CompensationBenefit>? CompensationBenefits { get; set; }
        public ICollection<JobOffer>? JobOffers { get; set; }
        public ICollection<CompanyTag>? CompanyTags { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
