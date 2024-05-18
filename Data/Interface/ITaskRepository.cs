using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;

namespace TaskManagement.Data.Interface
{
    public interface ITaskRepository
    {
        Task<TaskModel> CreateTask(TaskModel task);
        Task<List<TaskModel>> GetAllTask();
        Task<TaskModel> GetTaskById(string TaskCode);
        Task<TaskModel> UpdateTask(TaskModel task);
        Task<bool> DeleteTask(string TaskCode);
    }
}