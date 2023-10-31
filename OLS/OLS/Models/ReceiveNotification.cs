using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class ReceiveNotification
    {
        public int ReceiveNotificationId { get; set; }
        public int SendNotificationSendNotificationId { get; set; }
        public int CourseCourseId { get; set; }
        public int UserUserId { get; set; }

        public virtual Course CourseCourse { get; set; } = null!;
        public virtual SendNotification SendNotificationSendNotification { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
