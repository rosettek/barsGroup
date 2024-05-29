namespace TaskManager.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid User_id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get;  set; } = string.Empty;

        public string PasswordHash { get;  set; } = string.Empty;
    }
}
