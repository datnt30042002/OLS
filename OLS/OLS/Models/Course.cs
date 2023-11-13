using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Course
    {
        public Course()
        {
            Chapters = new HashSet<Chapter>();
            CourseEnrolleds = new HashSet<CourseEnrolled>();
            Feedbacks = new HashSet<Feedback>();
            ReceiveNotifications = new HashSet<ReceiveNotification>();
            SendNotifications = new HashSet<SendNotification>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? CourseInfomation { get; set; }
        public string? Image { get; set; }
        public string? VideoIntro { get; set; }
        public int? Fee { get; set; }
        public int Status { get; set; }
        public int LearningPathLearningPathId { get; set; }
        public int UserUserId { get; set; }

        public virtual LearningPath LearningPathLearningPath { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<CourseEnrolled> CourseEnrolleds { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<ReceiveNotification> ReceiveNotifications { get; set; }
        public virtual ICollection<SendNotification> SendNotifications { get; set; }
    }
}
