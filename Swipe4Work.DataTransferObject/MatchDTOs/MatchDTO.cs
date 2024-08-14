using Swipe4Work.Domain.Models;


namespace Swipe4Work.DataTransferObject
{
    public class MatchDTO
    {
        public int MatchId { get; set; }
        public int JobOfferId { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset MatchDate { get; set; }
        public bool IsAccepted { get; set; }

        public string? JobTitle { get; set; }
        public string? UserName { get; set; }

        //public MatchDTO(Match match)
        //{
        //    MatchId = match.MatchId;
        //    JobOfferId = match.JobOfferId;
        //    UserId = match.UserId;
        //    MatchDate = match.MatchDate;
        //    IsAccepted = match.IsAccepted;
        //    JobTitle = match.JobOffer?.Title;
        //    UserName = match.User?.UserName;
        //}
        //public MatchDTO() { }

    }
}
