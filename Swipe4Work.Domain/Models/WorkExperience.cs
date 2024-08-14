namespace Swipe4Work.Domain.Models
{
    public class WorkExperience
    {
        public int WorkExperienceId { get; set; }
        public int UserId { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }

        public User? User { get; set; }
    }
}
