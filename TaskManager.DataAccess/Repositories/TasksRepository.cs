using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Entities;
using TaskManager.Domain.Abstractions;

namespace TaskManager.DataAccess.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TaskManagerDbContext _context;

        public TasksRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Task>> Get()
        {
            var taskEntity = await _context.Tasks
                .AsNoTracking()
                .ToListAsync();

            var tasks = taskEntity.Select(b => Domain.Models.Task.Create(
                b.Id,
                b.Title,
                b.Description,
                b.Deadline,
                b.CreateDate,
                b.TaskStatus,
                b.IsDeleted).Task)
                .ToList();

            return tasks;
        }

        public async Task<List<Domain.Models.Task>> Get(Guid id)
        {
            var taskEntity = await _context.Tasks
                .AsNoTracking()
                .ToListAsync();

            var tasks = taskEntity.Select(b => Domain.Models.Task.Create(
                b.Id,
                b.Title,
                b.Description,
                b.Deadline,
                b.CreateDate,
                b.TaskStatus,
                b.IsDeleted).Task)
                .Where(b => b.Id == id)
                .ToList();

            return tasks;
        }

        public async Task<Guid> Create(Domain.Models.Task task)
        {
            var taskEntity = new TaskEntity
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Deadline = task.Deadline,
                CreateDate = task.CreateDate,
                TaskStatus = task.TaskStatus,
                IsDeleted = task.IsDeleted,
            };

            await _context.Tasks.AddAsync(taskEntity);
            await _context.SaveChangesAsync();

            return taskEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title,
                                      string description, DateTime deadline, bool taskStatus)
        {
            await _context.Tasks
                .Where(b => b.Id == id)
                .Where(b => b.IsDeleted == false)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, b => title)
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Deadline, b => deadline)
                .SetProperty(b => b.TaskStatus, b => taskStatus));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Tasks
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.IsDeleted, b => true));

            return id;
        }

        public async Task<bool> Check(Guid id)
        {
            var task = await _context.Tasks
                .Where(b => b.Id == id)
                .AsNoTracking()
                .ToListAsync();

            return task.Count != 0 && !task.Where(task => task.Id == id)
                                           .Any(task => task.IsDeleted == true);
        }
    }
}
