using JobSearchApp.Domain.Models;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class InterestDto
    {
        public int InterestId { get; set; }
        public int UserId { get; set; }
        public string InterestText { get; set; }

        public string UserName { get; set; }

        public InterestDto(Interest interest)
        {
            InterestId = interest.InterestId;
            UserId = interest.UserId;
            InterestText = interest.InterestText;
            UserName = interest.User?.UserName;
        }
    }
    public class CreateInterestDto
    {
        public int UserId { get; set; }
        public string InterestText { get; set; }
    }
    public class UpdateInterestDto
    {
        public string InterestText { get; set; }
    }
}