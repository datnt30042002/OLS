namespace OLS.DTO.Notifications.Admin
{
    public class NotificationUpdateAdminDTO
    {
        public int NotificationId { get; set; }
        public string? NotificationContent { get; set; }
        public int CourseCourseId { get; set; }
        public int UserUserId { get; set; }
    }
}
