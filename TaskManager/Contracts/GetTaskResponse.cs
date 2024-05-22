namespace TaskManager.Contracts
{
    public record GetTaskResponse(List<TaskDto> tasks);
    public record TaskDto(string Name, string Description, DateTime Deadline);

}
