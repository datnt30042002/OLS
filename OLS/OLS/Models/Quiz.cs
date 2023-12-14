using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }

        public int QuizId { get; set; }
        public int ChapterChapterId { get; set; }
        public string? QuizName { get; set; }

        public virtual Chapter ChapterChapter { get; set; } = null!;
        public virtual ICollection<Question> Questions { get; set; }
    }
}
