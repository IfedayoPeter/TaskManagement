using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;

namespace TaskManagement.Service.Interface
{
    public interface INotificationService
    {
        Task<Result<Notification>> CreateNotification(string Message,  string UserCode);
        Task<Result<List<Notification>>> GetUserNotifications(string UserCode);
        Task<Result<bool>> MarkAsRead(long Id);
    }
}
