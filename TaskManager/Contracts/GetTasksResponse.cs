namespace TaskManager.Contracts
{
    public record GetTasksResponse(Guid Id,
                                  string Title,
                                  string Description,
                                  DateTime Deadline,
                                  DateTime CreateDate,
                                  bool TaskStatus);

}
