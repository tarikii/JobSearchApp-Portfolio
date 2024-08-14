using System.Text.RegularExpressions;

namespace Swipe4Work.Domain.Models
{
    public class JobOffer
    {
        public int JobOfferId { get; set; }
        public int CompanyId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? JobType { get; set; }
        public string? ExperienceLevel { get; set; }
        public DateTimeOffset PostedDate { get; set; }
        public DateTimeOffset? ExpiredDate { get; set; }
        public bool IsActive { get; set; }
        public int EstimatedDurationDays { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }

        public Company? Company { get; set; }
        public ICollection<Application>? Applications { get; set; }
        public ICollection<Match>? Matches { get; set; }
    }
}
