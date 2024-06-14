using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Model;

namespace TaskManagement.Data
{
    public interface IDbContext
    {
        DbSet<TaskModel> Task { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Notification> Notifications { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}