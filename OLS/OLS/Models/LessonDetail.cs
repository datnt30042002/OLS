using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class LessonDetail
    {
        public LessonDetail()
        {
            Dicusses = new HashSet<Dicuss>();
        }

        public int LessonDetailId { get; set; }
        public string? Title { get; set; }
        public string? Video { get; set; }
        public string? Note { get; set; }
        public TimeSpan? Time { get; set; }
        public int LessonLessonId { get; set; }

        public virtual Lesson LessonLesson { get; set; } = null!;
        public virtual ICollection<Dicuss> Dicusses { get; set; }
    }
}
