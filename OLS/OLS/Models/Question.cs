using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string? CorrectAnswer { get; set; }
        public int QuizQuizId { get; set; }

        public virtual Quiz QuizQuiz { get; set; } = null!;
    }
}
