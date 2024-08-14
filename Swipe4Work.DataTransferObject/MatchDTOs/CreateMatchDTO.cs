namespace Swipe4Work.DataTransferObject
{
    public class CreateMatchDTO
    {
        public int JobOfferId { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset MatchDate { get; set; } = DateTimeOffset.Now;
        public bool IsAccepted { get; set; } = false;
    }

}
