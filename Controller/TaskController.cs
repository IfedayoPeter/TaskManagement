using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.DTOS;
using TaskManagement.Service.Interface;

namespace TaskManagement.Controller
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("/getAllTask")]
        public async Task<IActionResult> GetAllTask()
        {
            var result = await _taskService.GetAllTask();
            return Ok(result);
        }
        [HttpGet("/getTaskById")]
        public async Task<IActionResult> GetTaskById(string TaskCode)
        {
            var result = await _taskService.GetTaskById(TaskCode);
            return Ok(result);
        }

        [HttpPost("/createTask")]
        public async Task<IActionResult> CreateTask(TaskDTO taskDTO)
        {
            var result = await _taskService.CreateTask(taskDTO);
            return Ok(result);
        }

        [HttpPut("/UpdateTask")]
        public async Task<IActionResult> UpdateTask(string taskCode, TaskDTO tasksDTO)
        {
            var result = await _taskService.UpdateTask(taskCode, tasksDTO);
            return Ok(result);
        }

        [HttpDelete("/deleteTask")]
        public async Task<IActionResult> DeleteTask(string taskCode)
        {
            var result = await _taskService.DeleteTask(taskCode);
            return Ok(result);
        }
    }
}