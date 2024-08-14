namespace Swipe4Work.DataTransferObject
{
    public class CreateFeedbackDTO
    {
        public int ApplicationId { get; set; }
        public int RecruiterId { get; set; }
        public string? FeedbackText { get; set; }
        public DateTimeOffset FeedbackDate { get; set; } = DateTimeOffset.Now;
    }
}
