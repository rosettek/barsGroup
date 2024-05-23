namespace TaskManager.Domain.Models
{
    public class Task
    {
        public const int MAX_TITLE_LENGHT = 250;
        public const int MAX_DESCRIPTION_LENGHT = 500;

        private Task(Guid id, string title, string description,
            DateTime deadline, DateTime createDate, bool taskStatus, bool isDeleted)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            CreateDate = createDate;
            TaskStatus = taskStatus;
            IsDeleted = isDeleted;
        }

        public Guid Id { get; }

        public string Title { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public DateTime Deadline { get; } = DateTime.UtcNow;

        public DateTime CreateDate { get; } = DateTime.UtcNow;

        public bool TaskStatus { get; } = true;

        public bool IsDeleted { get; } = false;


        public static (Task Task, string Error) Create(Guid id, string title, string description,
            DateTime deadline, DateTime createDate, bool taskStatus, bool isDeleted)
        {
            string errorString = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGHT)
                errorString = "Error in task tittle";

            if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGHT)
                errorString = "Error in task description";

            var task = new Task(id, title, description, deadline, createDate, taskStatus, isDeleted);

            return (task, errorString);
        }
    }
}
