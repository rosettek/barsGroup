using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManager.Domain.Abstractions;
using TaskManager.Contracts.Task;


namespace TaskManager.Controllers
{
    [ApiController]
    [Route("task")]
    public class TaskController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITasksService tasksService, ILogger<TaskController> logger)
        {
            _tasksService = tasksService;
            _logger = _logger;
        }

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(typeof(List<GetTasksResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<List<GetTasksResponse>>> GetTasks()
        {
            var tasks = await _tasksService.GetAllTasks();
             
            if (tasks.Count == 0)
                return NoContent();

            var response = tasks
                .Select(b => new GetTasksResponse(b.Id, b.Title, b.Description,
                                                 b.Deadline, b.CreateDate, b.TaskStatus));
            return Ok(response);
        }

        [HttpGet]
        [Route("get/{id:guid}")]
        [ProducesResponseType(typeof(List<GetTasksResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<List<GetTasksResponse>>> GetTask(Guid id)
        {
            var task = await _tasksService.GetTask(id);

            if (task.Count == 0)
                return NoContent();

            var response = task
                .Select(b => new GetTasksResponse(b.Id, b.Title, b.Description,
                                                 b.Deadline, b.CreateDate, b.TaskStatus));
            return Ok(response);
        }

        [HttpPost]
        [Route("post")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CreateTaskRequest), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Guid>> CreatTaske([FromBody] CreateTaskRequest request)
        {
            var (task, error) = Domain.Models.Task
                .Create(Guid.NewGuid(), request.Title, request.Description,
                        request.Deadline, DateTime.UtcNow, true, false);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            Guid taskId = await _tasksService.CreateTask(task);

            return Ok(taskId);
        }

        [HttpPut]
        [Route("put/{id:guid}")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(UpdateTaskResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Guid>> UpdateTaske(Guid id, [FromBody] UpdateTaskResponse request)
        {
            if (request.CheckRequest())
            {
                return BadRequest();
            }

            if (!await _tasksService.UpdateTask(id, request.Title, request.Description,
                                                         request.Deadline, request.TaskStatus))
                return NotFound(id);


            
            return Ok(id);
        }

        [HttpDelete]
        [Route("delete/{id:guid}")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Guid>> DeleteTaske(Guid id)
        {
            if (await _tasksService.DeleteTask(id))
                return NotFound(id);

            return Ok(id);
        }
    }
}
