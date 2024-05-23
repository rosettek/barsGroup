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
            return await _taskRepositories.Get();
        }

        public async Task<Guid> CreateBook(Domain.Models.Task task)
        {
            return await _taskRepositories.Create(task);
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string tittle,
                                           string description, DateTime deadline, bool taskStatus)
        {
            return await _taskRepositories.Update(id, title, tittle,
                                                  description, deadline, taskStatus);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _taskRepositories.Delete(id);
        }
    }
}
