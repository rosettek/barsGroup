namespace UserAuthentication.Domain.Models
{
    public class User
    {
        public const int MAX_NAME_LENGHT = 50;
        public const int MAX_EMAIL_LENGHT = 50;

        public int a = 4;
        private User(Guid id, string name, string email, string passwordHash)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }

        public Guid Id { get; }

        public string Name { get; } = string.Empty;

        public string Email { get; } = string.Empty;

        public string PasswordHash { get; } = string.Empty;

        public static User Create(Guid id, string name, string email, string passwordHash)
        {
            return new User(id, name, email, passwordHash);
        }
    }
}
