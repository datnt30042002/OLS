using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class SendNotification
    {
        public SendNotification()
        {
            ReceiveNotifications = new HashSet<ReceiveNotification>();
        }

        public int SendNotificationId { get; set; }
        public string? NotificationContent { get; set; }
        public int? CourseCourseId { get; set; }
        public int? UserUserId { get; set; }

        public virtual Course? CourseCourse { get; set; }
        public virtual User? UserUser { get; set; }
        public virtual ICollection<ReceiveNotification> ReceiveNotifications { get; set; }
    }
}
