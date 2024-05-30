namespace UserAuthentication.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<Guid> Add(Models.User user);
        Task<List<Models.User>> Get();
        Task<Models.User> GetByEmail(string email);
    }
}