namespace UserAuthentication.Domain.Models
{
    public class User
    {
        public const int MAX_NAME_LENGHT = 50;
        public const int MAX_EMAIL_LENGHT = 50;

        public int a = 4;
        private User(Guid user_id, string name, string email, string passwordHash)
        {
            User_id = user_id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }

        public Guid User_id { get; }

        public string Name { get; } = string.Empty;

        public string Email { get; } = string.Empty;

        public string PasswordHash { get; } = string.Empty;

        public static User Create(Guid user_id, string name, string email, string passwordHash)
        {
            return new User(user_id, name, email, passwordHash);
        }
    }
}
