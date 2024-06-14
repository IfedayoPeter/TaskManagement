using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;
using TaskManagement.Service.Interface;

namespace TaskManagement.Controller
{
    [Authorize]
    [Route("api/notification/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpGet]
        [Route("get_notification_by_user_code")]
        public async Task<ActionResult> GetNotificationByCode(string userCode)
        {
            var result = new Result<List<Notification>>();
            result.RequestTime = DateTime.UtcNow;

            var response = await _notificationService.GetUserNotifications(userCode);
            result = response;
            result.ResponseTime = DateTime.UtcNow;
            return Ok(result);
        }

        [HttpGet]
        [Route("mark_as_read")]
        public async Task<ActionResult> MarkAsRead(long notificationId)
        {
            var result = new Result<bool>();
            result.RequestTime = DateTime.UtcNow;

            var response = await _notificationService.MarkAsRead(notificationId);
            result = response;
            result.ResponseTime = DateTime.UtcNow;
            return Ok(result);
        }
    }
}
