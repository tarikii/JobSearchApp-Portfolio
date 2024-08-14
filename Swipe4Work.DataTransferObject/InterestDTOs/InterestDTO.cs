using Swipe4Work.Domain.Models;

namespace Swipe4Work.DataTransferObject
{
    public class InterestDTO
    {
        public int InterestId { get; set; }
        public int UserId { get; set; }
        public string? InterestText { get; set; }

        public string? UserName { get; set; }

        //public InterestDTO(Interest interest)
        //{
        //    InterestId = interest.InterestId;
        //    UserId = interest.UserId;
        //    InterestText = interest.InterestText;
        //    UserName = interest.User?.UserName;
        //}
        //public InterestDTO() { }

    }
}
