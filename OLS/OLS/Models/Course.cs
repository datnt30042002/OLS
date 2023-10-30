using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Course
    {
        public Course()
        {
            Feedbacks = new HashSet<Feedback>();
            Lessons = new HashSet<Lesson>();
        }

        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? CourseInfo { get; set; }
        public string? Description { get; set; }
        public string? VideoIntro { get; set; }
        public int? Status { get; set; }
        public int? FeeStatus { get; set; }
        public int UserUserId { get; set; }
        public int CategoryCategoryId { get; set; }

        public virtual Category CategoryCategory { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
