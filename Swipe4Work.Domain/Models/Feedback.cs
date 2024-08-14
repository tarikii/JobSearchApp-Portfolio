namespace Swipe4Work.Domain.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int ApplicationId { get; set; }
        public int RecruiterId { get; set; }
        public string? FeedbackText { get; set; }
        public DateTimeOffset FeedbackDate { get; set; }


        public Application? Application { get; set; }
        public User? Recruiter { get; set; }
    }
}
