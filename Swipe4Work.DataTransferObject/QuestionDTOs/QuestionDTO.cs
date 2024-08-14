using Swipe4Work.Domain.Models;


namespace Swipe4Work.DataTransferObject
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }

        //public QuestionDTO(Question question)
        //{
        //    QuestionId = question.QuestionId;
        //    QuestionText = question.QuestionText;
        //}
        //public QuestionDTO() { }
    }
}
