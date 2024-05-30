using UserAuthentication.Domain.Models;

namespace UserAuthentication.Domain.Abstaraction
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}