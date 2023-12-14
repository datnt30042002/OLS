using OLS.DTO.Notifications.Admin;

namespace OLS.Services.Interface.Admin
{
    public interface INotificationManagerRepository
    {
        Task<List<NotificationReadAdminDTO>> GetAllNotifications();
        Task<List<NotificationReadAdminDTO>> FilterAllNotificationsByCourseId(int courseId);
        Task<NotificationCreateAdminDTO> CreateNotification(NotificationCreateAdminDTO notification);
        Task<NotificationUpdateAdminDTO> UpdateNotificationByNotificationId(int notificationId, NotificationUpdateAdminDTO updatedNotification);
        Task<bool> DeleteNotificationByNotificationId(int notificationId);
    }
}
