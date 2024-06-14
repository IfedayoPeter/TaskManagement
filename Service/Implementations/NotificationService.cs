using AutoMapper;
using TaskManagement.Data.Interface;
using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;
using TaskManagement.Service.Interface;

namespace TaskManagement.Service.Implementations
{

    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<NotificationService> _logger;
        private readonly WebSocketHandler _webSocketHandler;

        public NotificationService(
            INotificationRepository notificationRepository,
            IUserRepository userRepository,
            WebSocketHandler webSocketHandler,
            ILogger<NotificationService> logger
            )
        {
            _notificationRepository = notificationRepository;
            _userRepository = userRepository;
            _webSocketHandler = webSocketHandler;
            _logger = logger;
        }

        public async Task<Result<Notification>> CreateNotification(string message, string UserCode)
        {
            Result<Notification> result = new(false);

            try
            {
                var user = await _userRepository.GetUserByCode(UserCode);
                if (user != null)
                {
                    var notification = new Notification
                    {
                        UserCode = UserCode,
                        Message = message,
                        IsRead = false
                    };
                    var response = await _notificationRepository.CreateNotification(notification);

                    if (response != null)
                    {
                        result.SetSuccess(response, $"Notification Created Successfully !");
                        await _webSocketHandler.BroadcastAsync(message);
                    }
                    else
                    {
                        result.SetError("Notification not created", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating notification");
                result.SetError(ex.ToString(), "Error while creating notification");
            }

            return result;
        }


public async Task<Result<List<Notification>>> GetUserNotifications(string userCode)
{
    Result<List<Notification>> result = new(false);

    try
    {
        var response = await _notificationRepository.GetUserNotifications(userCode);

        if (response.Count == 0)
        {
            result.SetError("user has no notification", "Notification does not exist");
        }
        else
        {
            result.SetSuccess(response.ToList(), "Notifications retrieved successfully");
        }

    }
    catch (Exception e)
    {
        _logger.LogError(e, "Error retrieving Notification");
        result.SetError(e.ToString(), "Notifications does not exist");
    }

    return result;
}


public async Task<Result<bool>> MarkAsRead(long id)
{
    Result<bool> result = new(false);

    try
    {
        var response = await _notificationRepository.MarkAsRead(id);
        if (response == false)
        {
            result.SetError("Error", $"user has no unread notfication");
        }
        else
        {
            result.SetSuccess(response, $"Notification marked as read.");

        }
        result.Content = response;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error while Updating Notification");
        result.SetError(ex.ToString(), "Error while Updating Notification");
    }
    return result;
}
    }
}
