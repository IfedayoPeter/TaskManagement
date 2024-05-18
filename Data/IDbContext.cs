using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Model;

namespace TaskManagement.Data
{
    public interface IDbContext
    {
        DbSet<TaskModel> Task { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}