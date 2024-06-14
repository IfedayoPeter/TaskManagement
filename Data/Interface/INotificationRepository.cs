using TaskManagement.Domain.Model;

namespace TaskManagement.Data.Interface

{
    public interface INotificationRepository
    {
        Task<Notification> CreateNotification(Notification notification);
        Task<List<Notification>> GetUserNotifications(string userCode);
        Task<bool> MarkAsRead(long notificationId);
    }
}
