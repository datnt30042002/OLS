using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Discuss
    {
        public Discuss()
        {
            Asks = new HashSet<Ask>();
        }

        public int DiscussId { get; set; }
        public int LessonLessonId { get; set; }

        public virtual Lesson LessonLesson { get; set; } = null!;
        public virtual ICollection<Ask> Asks { get; set; }
    }
}
