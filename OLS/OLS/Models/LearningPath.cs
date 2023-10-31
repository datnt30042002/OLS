using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class LearningPath
    {
        public LearningPath()
        {
            Courses = new HashSet<Course>();
        }

        public int LearningPathId { get; set; }
        public string? LearningPathName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
