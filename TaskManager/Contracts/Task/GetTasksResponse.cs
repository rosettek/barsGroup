using System.ComponentModel.DataAnnotations;

namespace TaskManager.Contracts.Task
{
    public record GetTasksResponse(Guid Id,
                                  string Title,
                                  string Description,
                                  DateTime Deadline,
                                  DateTime CreateDate,
                                  bool TaskStatus);

}
