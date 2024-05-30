namespace TaskManager.Contracts.Task
{
    public record UpdateTaskResponse(string Title,
                                     string Description,
                                     DateTime Deadline,
                                     bool TaskStatus)
    {
        public bool CheckRequest()
        {
            return string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(Description);
        }
    }
}
