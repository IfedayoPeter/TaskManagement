using AutoMapper;
using Azure;
using TaskManagement.Data.Interface;
using TaskManagement.Domain.DTOS;
using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;
using TaskManagement.Service.Interface;
using TaskManagement.Services.Helpers;

namespace TaskManagement.Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        private readonly ILogger<TaskService> _logger;
        public TaskService(
            ITaskRepository taskRepository,
            INotificationService notificationService,
            IMapper mapper,
            ILogger<TaskService> logger
        )
        {
            _taskRepository = taskRepository;
            _notificationService = notificationService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<TaskDTO>> CreateTask(TaskDTO taskDTO)
        {
            Result<TaskDTO> result = new(false);

            try
            {
                //assign a random code to taskcode
                taskDTO.TaskCode = new RandomGenerator().GenerateRandomCode(5);
                //map taskModel to taskDTO
                var task = _mapper.Map<TaskModel>(taskDTO);
                var response = await _taskRepository.CreateTask(task);

                if (response != null)
                {
                    //map taskDTO to response 
                    result.SetSuccess(_mapper.Map<TaskDTO>(response), $"Task with code {response.TaskCode} Created Successfully !");

                    string message = $"You have been assigned a task: {taskDTO.AssignedTo}";
                    await _notificationService.CreateNotification(message, taskDTO.AssignedTo);//sends notification to who the task was assigned to
                }

                else
                {
                    result.SetError("Task not created", "");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Task");
                result.SetError(ex.ToString(), "Error while creating Task");
            }
            return result;
        }

        public async Task<Result<List<TaskModel>>> GetAllTask()
        {
            Result<List<TaskModel>> result = new(false);

            try
            {
                var response = await _taskRepository.GetAllTask();

                if (response != null)
                {
                    result.SetSuccess(response.ToList(), "Retrieved Successfully.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting Task");
                result.SetError(ex.ToString(), "Error while getting Task");
            }
            return result;
        }

        public async Task<Result<TaskModel>> GetTaskById(string TaskCode)
        {
            Result<TaskModel> result = new(false);

            try
            {
                var response = await _taskRepository.GetTaskById(TaskCode);

                if (response != null)
                {
                    result.SetSuccess(response, " Task Retrieved Successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting Task");
                result.SetError(ex.ToString(), "Error while getting Task");
            }
            return result;
        }

        public async Task<Result<bool>> UpdateTask(string TaskCode, TaskDTO taskDTO)
        {
            Result<bool> result = new(false);

            try
            {
                //get the task to be updated
                var existingTask = await _taskRepository.GetTaskById(TaskCode);

                //check if task exist
                if (existingTask == null)
                {
                    result.SetError("Task does not exit", "Check your taskCode and try again");
                }

                _mapper.Map(taskDTO, existingTask);

                //assign var response to existingTask and update task
                var response = await _taskRepository.UpdateTask(existingTask);

                //a taskModel response is exped if update is successful.
                if (response != null)
                {
                    result.SetSuccess(true, "Task updated successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating Task");
                result.SetError(ex.ToString(), "Error while updating Task");
            }
            return result;
        }

        public async Task<Result<bool>> DeleteTask(string TaskCode)
        {
            Result<bool> result = new(false);

            try
            {
                var response = await _taskRepository.DeleteTask(TaskCode);
                result.Content = response;

                if (!response)
                {
                    result.SetError("Task not deleted", $"TaskCode is incorrect or does not exist");
                }
                else
                {
                    result.SetSuccess(response, $"Task with Id {TaskCode} deleted Successfully !");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while removing Task");
                result.SetError(ex.ToString(), "Error while removing Task");
            }

            return result;
        }
    }
}