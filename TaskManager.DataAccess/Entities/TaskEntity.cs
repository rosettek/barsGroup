namespace TaskManager.DataAccess.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Deadline { get; set; } = DateTime.UtcNow;

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public bool TaskStatus { get; set; } = true;
        
        public bool IsDeleted { get; set; } = false;

        
        public Guid UserID { get; set; }

        public UserEntity? User { get; set; }
    }
}
