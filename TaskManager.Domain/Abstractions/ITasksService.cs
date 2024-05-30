namespace TaskManager.Domain.Abstractions
{
    public interface ITasksService
    {
        Task<Guid> CreateTask(Models.Task task);
        Task<bool> DeleteTask(Guid id);
        Task<List<Models.Task>> GetAllTasks();
        Task<List<Models.Task>> GetTask(Guid id);
        Task<bool> UpdateTask(Guid id, string title, string description, DateTime deadline, bool taskStatus);
    }
}