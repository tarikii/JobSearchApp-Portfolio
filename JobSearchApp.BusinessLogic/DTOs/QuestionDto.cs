    using JobSearchApp.Domain.Models;

    namespace JobSearchApp.BusinessLogic.DTOs
    {
        public class QuestionDto
        {
            public int QuestionId { get; set; }
            public string QuestionText { get; set; }

            public QuestionDto(Question question)
            {
                QuestionId = question.QuestionId;
                QuestionText = question.QuestionText;
            }
            public QuestionDto(){}
        }
        public class CreateQuestionDto
        {
            public string QuestionText { get; set; }
        }
        public class UpdateQuestionDto
        {
            public int QuestionId { get; set; }
            public string QuestionText { get; set; }
        }
    }