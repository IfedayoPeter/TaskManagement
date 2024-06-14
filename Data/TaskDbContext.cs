using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;

namespace TaskManagement.Data
{
    public class TaskDbContext : DbContext, IDbContext
    {
        private readonly DbContextOptions<TaskDbContext> options;
        //private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeProvider _dateTime;

        public TaskDbContext(
        DbContextOptions<TaskDbContext> options,
        //ICurrentUserService currentUserService,
        IDateTimeProvider dateTime) : base(options)

        {
            this.options = options;
            //_currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<TaskModel> Task { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUserService?.UserId != null ? _currentUserService.UserId : "SYSTEM";
                        entry.Entity.CreatedOn = _dateTime != null ? _dateTime.Now : DateTime.Now;
                        //entry.Entity.LastModifiedBy = _currentUserService?.UserId != null ? _currentUserService.UserId : "SYSTEM";
                        entry.Entity.LastModifiedOn = _dateTime != null ? _dateTime.Now : DateTime.Now;
                        break;

                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = _currentUserService?.UserId != null ? _currentUserService.UserId : "SYSTEM";
                        entry.Entity.LastModifiedOn = _dateTime != null ? _dateTime.Now : DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<TaskModel>()
                   .ToTable("task")
                   .HasKey(x => x.TaskCode);
            builder.Entity<User>()
                    .ToTable("user")
                    .HasKey(x => x.UserCode);
            builder.Entity<Notification>()
                   .ToTable("notifications")
                   .HasKey(x => x.Id);
            base.OnModelCreating(builder);
        }
    }
}