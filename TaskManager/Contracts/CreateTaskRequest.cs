namespace TaskManager.Contracts
{
    public record CreateTaskRequest(string Title,
                                    string Description,
                                    DateTime Deadline,
                                    DateTime CreateDate,
                                    bool TaskStatus,
                                    bool IsDeleted);
}
