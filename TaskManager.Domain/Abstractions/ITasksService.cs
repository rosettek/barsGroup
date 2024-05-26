namespace TaskManager.Application.Services
{
    public interface ITasksService
    {
        Task<Guid> CreateTask(Domain.Models.Task task);
        Task<bool> DeleteTask(Guid id);
        Task<List<Domain.Models.Task>> GetAllTasks();
        Task<List<Domain.Models.Task>> GetTask(Guid id);
        Task<Guid> UpdateTask(Guid id, string title, string description, DateTime deadline, bool taskStatus);
    }
}