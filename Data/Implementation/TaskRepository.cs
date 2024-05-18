using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Interface;
using TaskManagement.Domain.Model;

namespace TaskManagement.Data.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IDbContext _context;
        public TaskRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task<TaskModel> CreateTask(TaskModel task)
        {
            await _context.Task.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<List<TaskModel>> GetAllTask()
        {
            var result = await _context.Task.ToListAsync();
            return result;
        }

        public async Task<TaskModel> GetTaskById(string TaskCode)
        {
            var result = await _context.Task
            .Where(x => x.TaskCode == TaskCode)
            .FirstOrDefaultAsync();

            return result;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task)
        {
            //_context.Task.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(string TaskCode)
        {
             var task = await _context.Task
                        .Where(x => x.TaskCode == TaskCode)
                        .FirstAsync();

            var result = _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}