using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Notifications.Admin;
using OLS.Services.Interface.Admin;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationManagerRepository notificationManagerRepo;
        public NotificationController(INotificationManagerRepository notificationManagerRepo)
        {
            this.notificationManagerRepo = notificationManagerRepo;
        }

        // Get all notifications 
        [HttpGet("/getAllNotifications")]
        public async Task<ActionResult<IEnumerable<NotificationReadAdminDTO>>> GetAllNotifications()
        {
            try
            {
                var notifications = await notificationManagerRepo.GetAllNotifications();
                return Ok(notifications);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Filter all notifications by course id 
        [HttpGet("/filterAllNotificationsByCourseId")]
        public async Task<ActionResult<IEnumerable<NotificationReadAdminDTO>>> FilterAllNotificationsByCourseId(int courseId)
        {
            try
            {
                var notifications = await notificationManagerRepo.FilterAllNotificationsByCourseId(courseId); 
                return Ok(notifications);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new notification
        [HttpPost("/createNotification")]
        public async Task<ActionResult<IEnumerable<NotificationCreateAdminDTO>>> CreateNotification(NotificationCreateAdminDTO notification)
        {
            try
            {
                var newNotification = await notificationManagerRepo.CreateNotification(notification);
                return Ok(newNotification);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update notification by notificationId 
        [HttpPut("/updateNotificationByNotificationId")]
        public async Task<ActionResult<IEnumerable<NotificationUpdateAdminDTO>>> UpdateNotificationByNotificationId(int notificationId, NotificationUpdateAdminDTO updatedNotification)
        {
            try
            {
                var existingNotification = await notificationManagerRepo.UpdateNotificationByNotificationId(notificationId, updatedNotification);
                return Ok(existingNotification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete notification by notificationId 
        [HttpDelete("/deleteNotificationByNotificationId")]
        public async Task<ActionResult> DeleteNotificationByNotificationId(int notificationId)
        {
            try
            {
                var existingNotification = await notificationManagerRepo.DeleteNotificationByNotificationId(notificationId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
