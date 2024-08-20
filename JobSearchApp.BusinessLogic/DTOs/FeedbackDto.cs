using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class FeedbackDto
    {
        public int FeedbackId { get; set; }
        public int ApplicationId { get; set; }
        public int RecruiterId { get; set; }
        public string? FeedbackText { get; set; }
        public DateTimeOffset FeedbackDate { get; set; }
        public string? RecruiterName { get; set; }
        public JobOffer JobOffer { get; set; }
        public User Recruiter {  get; set; } 

        public FeedbackDto(Feedback feedback)
        {
            FeedbackId = feedback.FeedbackId;
            ApplicationId = feedback.ApplicationId;
            RecruiterId = feedback.RecruiterId;
            FeedbackText = feedback.FeedbackText;
            FeedbackDate = feedback.FeedbackDate;
            RecruiterName = feedback.Recruiter?.UserName;
        }

        public FeedbackDto()
        {


        }
    }
    public class CreateFeedbackDto
    {
        public int ApplicationId { get; set; }
        public int RecruiterId { get; set; }
        public string? FeedbackText { get; set; }
        public DateTimeOffset FeedbackDate { get; set; } = DateTimeOffset.Now;
    }
    
    public class UpdateFeedbackDto
    {
        public int FeedbackId { get; set; }
        public string? FeedbackText { get; set; }
    }
}