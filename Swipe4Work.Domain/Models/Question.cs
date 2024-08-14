namespace Swipe4Work.Domain.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }

        public ICollection<Answer>? Answers { get; set; }
    }
}
