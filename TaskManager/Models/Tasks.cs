namespace TaskManager.Models
{
    public class Tasks
    {
        public Tasks(string name, string description, DateTime deadline)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Deadline = deadline;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }
    }
}
