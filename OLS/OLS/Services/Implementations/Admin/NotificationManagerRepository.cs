using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Notifications.Admin;
using OLS.DTO.Quizzes.Admin;
using OLS.Models;
using OLS.Services.Interface.Admin;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Admin
{
    public class NotificationManagerRepository : INotificationManagerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public NotificationManagerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all notifications 
        public async Task<List<NotificationReadAdminDTO>> GetAllNotifications()
        {
            try
            {
                var notifications = await db.Notifications
                    .OrderByDescending(noti => noti.NotificationContent)
                    .ToListAsync();
                var notificationReadAdminDTO = mapper.Map<List<NotificationReadAdminDTO>>(notifications);

                return notificationReadAdminDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Filter all notifications by course id 
        public async Task<List<NotificationReadAdminDTO>> FilterAllNotificationsByCourseId(int courseId)
        {
            try
            {
                var notifications = await db.Notifications
                    .Where(noti => noti.CourseCourseId ==  courseId)
                    .ToListAsync ();
                var notificationReadAdminDTO = mapper.Map<List<NotificationReadAdminDTO>>(notifications);

                return notificationReadAdminDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new notification 
        public async Task<NotificationCreateAdminDTO> CreateNotification(NotificationCreateAdminDTO notification)
        {
            try
            {
                var newNoti = mapper.Map<Notification>(notification);
                var createNoti = await db.Notifications.AddAsync(newNoti);
                await db.SaveChangesAsync();
                var notificationCreateAdminDTO = mapper.Map<NotificationCreateAdminDTO>(newNoti);

                return notificationCreateAdminDTO;
            } catch(Exception  ex)
            {
                throw new Exception (ex.Message);
            }
        }

        // Update notification by notificationId 
        public async Task<NotificationUpdateAdminDTO> UpdateNotificationByNotificationId(int notificationId, NotificationUpdateAdminDTO updatedNotification)
        {
            try
            {
                var existingNotification = await db.Notifications
                    .Where(noti => noti.NotificationId == notificationId)
                    .FirstOrDefaultAsync();

                if(existingNotification == null)
                {
                    Console.WriteLine("Not found notification");
                }

                mapper.Map(updatedNotification, existingNotification);
                await db.SaveChangesAsync();
                var notificationUpdateAdminDTO = mapper.Map<NotificationUpdateAdminDTO>(existingNotification);

                return notificationUpdateAdminDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete notification by notificationId
        public async Task<bool> DeleteNotificationByNotificationId(int notificationId)
        {
            try
            {
                var existingNotification = await db.Notifications
                    .Where(noti => noti.NotificationId == notificationId)
                    .FirstOrDefaultAsync();

                if (existingNotification == null)
                {
                    Console.WriteLine("Not found notification");
                }

                db.Notifications.Remove(existingNotification);
                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
