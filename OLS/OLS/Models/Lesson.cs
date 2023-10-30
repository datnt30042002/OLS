using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            LessonDetails = new HashSet<LessonDetail>();
            Quizzes = new HashSet<Quiz>();
        }

        public int LessonId { get; set; }
        public string? Name { get; set; }
        public int CourseCourseId { get; set; }

        public virtual Course CourseCourse { get; set; } = null!;
        public virtual ICollection<LessonDetail> LessonDetails { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
