namespace TaskManager.Contracts
{
    public record CreateTaskRequest(string Title,
                                    string Description,
                                    DateTime Deadline);
}
