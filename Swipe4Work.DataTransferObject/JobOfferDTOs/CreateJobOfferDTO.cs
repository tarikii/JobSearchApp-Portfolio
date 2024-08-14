
namespace Swipe4Work.DataTransferObject
{
    public class CreateJobOfferDTO
    {
        public int CompanyId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? JobType { get; set; }
        public string? ExperienceLevel { get; set; }
        public DateTimeOffset PostedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ExpiredDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int EstimatedDurationDays { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
    }
}
