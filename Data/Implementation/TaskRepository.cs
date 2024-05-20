using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Interface;
using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;

namespace TaskManagement.Data.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly WebSocketHandler _webSocketHandler;
        private readonly IDbContext _context;
        public TaskRepository(IDbContext context, WebSocketHandler webSocketHandler)
        {
            _context = context;
            _webSocketHandler = webSocketHandler;
        }

        public async Task<TaskModel> CreateTask(TaskModel task)
        {
            await _context.Task.AddAsync(task);
            await _context.SaveChangesAsync();

            // Broadcast the new task to all connected clients
            var taskJson = JsonSerializer.Serialize(task);
            await _webSocketHandler.BroadcastAsync(taskJson);

            return task;
        }

        public async Task<List<TaskModel>> GetAllTask()
        {
            var result = await _context.Task.ToListAsync();

            // Broadcast the task to all connected clients
            var taskJson = JsonSerializer.Serialize(result);
            await _webSocketHandler.BroadcastAsync(taskJson);
            
            return result;
        }

        public async Task<TaskModel> GetTaskById(string TaskCode)
        {
            var result = await _context.Task
            .Where(x => x.TaskCode == TaskCode)
            .FirstOrDefaultAsync();

            // Broadcast the task to all connected clients
            var taskJson = JsonSerializer.Serialize(result);
            await _webSocketHandler.BroadcastAsync(taskJson);

            return result;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task)
        {
            //_context.Task.Update(task);
            await _context.SaveChangesAsync();
            // Broadcast the updated task to all connected clients
            var taskJson = JsonSerializer.Serialize(task);
            await _webSocketHandler.BroadcastAsync(taskJson);
            return task;
        }

        public async Task<bool> DeleteTask(string TaskCode)
        {
            var task = await _context.Task
                       .Where(x => x.TaskCode == TaskCode)
                       .FirstAsync();

            var result = _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            // Broadcast message to all connected clients
            await _webSocketHandler.BroadcastAsync("Task deleted successfully");

            return true;
        }

    }
}