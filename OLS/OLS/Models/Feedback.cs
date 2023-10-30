using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public string? Feedback1 { get; set; }
        public int CourseCourseId { get; set; }

        public virtual Course CourseCourse { get; set; } = null!;
    }
}
