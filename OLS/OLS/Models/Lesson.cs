using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Lessondetails = new HashSet<Lessondetail>();
        }

        public int LessonId { get; set; }
        public string? Name { get; set; }
        public int CourseCourseId { get; set; }

        public virtual Course CourseCourse { get; set; } = null!;
        public virtual ICollection<Lessondetail> Lessondetails { get; set; }
    }
}
