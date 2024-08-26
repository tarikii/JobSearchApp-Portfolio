using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class QuestionAnswerDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public AnswerDto Answer { get; set; }
    }
}
