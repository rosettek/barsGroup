namespace TaskManager.DataAccess.Repositories
{
    public interface ITasksRepository
    {
        Task<Guid> Create(Domain.Models.Task task);
        Task<Guid> Delete(Guid id);
        Task<List<Domain.Models.Task>> Get();
        Task<Guid> Update(Guid id, string title, string tittle, string description, DateTime deadline, bool taskStatus);
    }
}