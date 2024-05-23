





namespace TaskManager.Application.Services
{
    public interface ITasksService
    {
        Task<Guid> CreateBook(Domain.Models.Task task);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Domain.Models.Task>> GetAllTasks();
        Task<Guid> UpdateBook(Guid id, string title, string tittle, string description, DateTime deadline, bool taskStatus);
    }
}