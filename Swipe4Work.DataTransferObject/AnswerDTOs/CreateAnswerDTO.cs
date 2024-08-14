namespace Swipe4Work.DataTransferObject
{
    public class CreateAnswerDTO
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string? AnswerText { get; set; }
        public bool IsFeatured { get; set; }
    }
}
