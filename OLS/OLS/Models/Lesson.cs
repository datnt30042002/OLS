using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Discusses = new HashSet<Discuss>();
        }

        public int LessonId { get; set; }
        public string? Title { get; set; }
        public string? Video { get; set; }
        public TimeSpan? Time { get; set; }
        public int ChapterChapterId { get; set; }

        public virtual Chapter ChapterChapter { get; set; } = null!;
        public virtual ICollection<Discuss> Discusses { get; set; }
    }
}
