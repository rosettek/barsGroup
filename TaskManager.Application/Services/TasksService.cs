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

        public async Task<Guid> UpdateTask(Guid id, string title, string description,
                                           DateTime deadline, bool taskStatus)
        {
            return await _taskRepositories.Update(id, title,description,
                                                  deadline, taskStatus);
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            var tmp = await GetTask(id);

            if (tmp.Count == 0)
                return false;

            await _taskRepositories.Delete(id);

            return true;
        }
    }
}
