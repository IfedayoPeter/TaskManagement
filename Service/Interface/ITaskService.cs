using TaskManagement.Domain.DTOS;
using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;

namespace TaskManagement.Service.Interface
{
    public interface ITaskService
    {
         Task<Result<TaskDTO>> CreateTask(TaskDTO taskDTO);
         Task<Result<List<TaskModel>>> GetAllTask();
         Task<Result<TaskModel>> GetTaskById( string TaskCode);
         Task<Result<bool>> UpdateTask(string TaskCode, TaskDTO taskDTO);
         Task<Result<bool>> DeleteTask(string TaskCode);
    }
}