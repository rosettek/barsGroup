namespace UserAuthentication.Inafrastructure
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = String.Empty;

        public int ExpitesHours { get; set; }
    }
}