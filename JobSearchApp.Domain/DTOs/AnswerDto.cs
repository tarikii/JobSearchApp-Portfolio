using JobSearchApp.Domain.Models;

namespace JobSearchApp.Domain.DTOs
{
    public class AnswerDto
    {
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public bool IsFeatured { get; set; }

        public string UserName { get; set; }
        public string QuestionText { get; set; }

        public AnswerDto(Answer answer)
        {
            AnswerId = answer.AnswerId;
            UserId = answer.UserId;
            QuestionId = answer.QuestionId;
            AnswerText = answer.AnswerText;
            IsFeatured = answer.IsFeatured;
            UserName = answer.User?.UserName;
            QuestionText = answer.Question?.QuestionText;
        }
    }
}