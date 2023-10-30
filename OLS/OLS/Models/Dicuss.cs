using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Dicuss
    {
        public Dicuss()
        {
            Asks = new HashSet<Ask>();
        }

        public int DicussId { get; set; }
        public int? LessonDetailLessonDetailId { get; set; }

        public virtual LessonDetail? LessonDetailLessonDetail { get; set; }
        public virtual ICollection<Ask> Asks { get; set; }
    }
}
