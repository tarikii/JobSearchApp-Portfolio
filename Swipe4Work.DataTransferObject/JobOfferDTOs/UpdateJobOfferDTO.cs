
namespace Swipe4Work.DataTransferObject
{
    public class UpdateJobOfferDTO
    {
        public int JobOfferId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? JobType { get; set; }
        public string? ExperienceLevel { get; set; }
        public DateTimeOffset? ExpiredDate { get; set; }
        public bool IsActive { get; set; }
        public int EstimatedDurationDays { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
    }
}
