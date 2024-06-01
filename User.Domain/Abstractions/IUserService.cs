using UserAuthentication.Domain.Models;

namespace UserAuthentication.Domain.Abstractions
{
    public interface IUserService
    {
        Task<string> Login(string email, string password);
        Task<Guid> Register(string username, string email, string password);
        Task<List<User>> GetAllUser();

    }
}