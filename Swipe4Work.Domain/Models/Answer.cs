namespace Swipe4Work.Domain.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string? AnswerText { get; set; }
        public bool IsFeatured { get; set; }


        public User? User { get; set; }
        public Question? Question { get; set; }
    }
}
