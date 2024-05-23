using Docker.DotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Services;
using TaskManager.Contracts;


namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController: ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TaskController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetTasksResponse>>> GetTasks()
        {
            var tasks = await _tasksService.GetAllTasks();

            var response = tasks
                .Select(b => new GetTasksResponse(b.Id, b.Title, b.Description,
                                                 b.Deadline, b.CreateDate, b.TaskStatus,  b.IsDeleted));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreatTaske([FromBody] CreateTaskRequest request)
        {
            var (task, error) = Domain.Models.Task
                .Create(Guid.NewGuid(),
                        request.Title, request.Description, request.Deadline,
                        request.CreateDate, request.TaskStatus, request.IsDeleted);

            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }
            
            Guid taskId = await _tasksService.CreateTask(task);

            return Ok(taskId);
        }

        //private readonly TaskDbContext _dbContext;

        //public TaskController(TaskDbContext dbContext) 
        //{
        //    _dbContext = dbContext;
        //}

        //[HttpGet]
        //public async Task<IAsyncResult> Get()
        //{
        //    var taskDtos = await _dbContext.TaskSet
        //        .Select(n => new TaskDto( n.Name, n.Description, n.Deadline))
        //        .ToListAsync();
        //    return (IAsyncResult)Ok(new GetTaskResponse(taskDtos));
        //}


        //[HttpPost]
        //public async Task<IAsyncResult> Create([FromBody] CreateTaskRequest request)
        //{
        //    var task = new Tasks(request.Title, request.Description, request.Deadline);
        //    await _dbContext.TaskSet.AddAsync(task);
        //    await _dbContext.SaveChangesAsync();
        //    return (IAsyncResult)Ok();
        //}
    }
}
