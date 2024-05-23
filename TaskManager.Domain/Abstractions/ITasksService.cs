namespace TaskManager.Application.Services
{
    public interface ITasksService
    {
        Task<Guid> CreateTask(Domain.Models.Task task);
        Task<Guid> DeleteTask(Guid id);
        Task<List<Domain.Models.Task>> GetAllTasks();
        Task<Guid> UpdateTask(Guid id, string title, string tittle, string description, DateTime deadline, bool taskStatus);
    }
}