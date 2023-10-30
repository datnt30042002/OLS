using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class CourseEnroll
    {
        public int CourseEnrollId { get; set; }
        public string? LessonCurrent { get; set; }
        public DateTime? EnrollDate { get; set; }
        public int? Status { get; set; }
        public int UserUserId { get; set; }
        public int CourseCourseId { get; set; }

        public virtual Course CourseCourse { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
