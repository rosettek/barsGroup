namespace TaskManager.Domain.Abstractions
{
    public interface ITasksRepository
    {
        Task<Guid> Create(Models.Task task);
        Task<Guid> Delete(Guid id);
        Task<List<Models.Task>> Get();
        Task<List<Models.Task>> Get(Guid id);
        Task<Guid> Update(Guid id, string title, string description, DateTime deadline, bool taskStatus);
        Task<bool> Check(Guid id);
    }
}