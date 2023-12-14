using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public string? AnswerContent { get; set; }
        public int QuestionQuestionId { get; set; }
        public int? IsTrue { get; set; }

        public virtual Question QuestionQuestion { get; set; } = null!;
    }
}
