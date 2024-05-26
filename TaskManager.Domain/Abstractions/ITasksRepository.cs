namespace TaskManager.DataAccess.Repositories
{
    public interface ITasksRepository
    {
        Task<Guid> Create(Domain.Models.Task task);
        Task<Guid> Delete(Guid id);
        Task<List<Domain.Models.Task>> Get();
        Task<List<Domain.Models.Task>> Get(Guid id);
        Task<Guid> Update(Guid id, string title, string description, DateTime deadline, bool taskStatus);
        Task<bool> Check(Guid id);
    }
}