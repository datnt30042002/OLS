using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string? NotificationContent { get; set; }
        public int CourseCourseId { get; set; }
        public int UserUserId { get; set; }

        public virtual Course CourseCourse { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
