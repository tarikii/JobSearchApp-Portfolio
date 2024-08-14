using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject
{
    public class FeedbackDTO
    {
        public int FeedbackId { get; set; }
        public int ApplicationId { get; set; }
        public int RecruiterId { get; set; }
        public string? FeedbackText { get; set; }
        public DateTimeOffset FeedbackDate { get; set; }

        public string? RecruiterName { get; set; }

        //public FeedbackDTO(Feedback feedback)
        //{
        //    FeedbackId = feedback.FeedbackId;
        //    ApplicationId = feedback.ApplicationId;
        //    RecruiterId = feedback.RecruiterId;
        //    FeedbackText = feedback.FeedbackText;
        //    FeedbackDate = feedback.FeedbackDate;
        //    RecruiterName = feedback.Recruiter?.UserName;
        //}
        //public FeedbackDTO() { }

    }
}
