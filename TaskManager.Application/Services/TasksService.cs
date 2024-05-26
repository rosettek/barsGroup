using TaskManager.DataAccess.Repositories;

namespace TaskManager.Application.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _taskRepositories;

        public TasksService(ITasksRepository taskRepositories)
        {
            _taskRepositories = taskRepositories;
        }

        public async Task<List<Domain.Models.Task>> GetAllTasks()
        {
            var tasks = await _taskRepositories.Get();
            return tasks.Where(task => task.IsDeleted == false).ToList();
        }

        public async Task<List<Domain.Models.Task>> GetTask(Guid id)
        {
            var task = await _taskRepositories.Get(id);
            return task.Where(task => task.IsDeleted == false).ToList();
        }

        public async Task<Guid> CreateTask(Domain.Models.Task task)
        {
            return await _taskRepositories.Create(task);
        }

        public async Task<bool> UpdateTask(Guid id, string title, string description,
                                           DateTime deadline, bool taskStatus)
        {
            await _taskRepositories.Update(id, title, description,
                                                  deadline, taskStatus);

            return await _taskRepositories.Check(id);
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            await _taskRepositories.Delete(id);

            return await _taskRepositories.Check(id);
        }
    }
}
