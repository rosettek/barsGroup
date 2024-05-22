using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskManager.Contracts;
using TaskManager.DataAccess;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController: ControllerBase
    {
        private readonly TaskDbContext _dbContext;

        public TaskController(TaskDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IAsyncResult> Get()
        {
            var taskDtos = await _dbContext.TaskSet
                .Select(n => new TaskDto( n.Name, n.Description, n.Deadline))
                .ToListAsync();
            return (IAsyncResult)Ok(new GetTaskResponse(taskDtos));
        }


        [HttpPost]
        public async Task<IAsyncResult> Create([FromBody] CreateTaskRequest request)
        {
            var task = new Tasks(request.Title, request.Description, request.Deadline);
            await _dbContext.TaskSet.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return (IAsyncResult)Ok();
        }
    }
}
