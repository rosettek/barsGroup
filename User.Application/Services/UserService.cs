using UserAuthentication.Domain.Abstaraction;
using UserAuthentication.Domain.Abstractions;
using UserAuthentication.Domain.Models;

namespace UserAuthentication.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository userRepository,
                           IPasswordHasher passwordHasher,
                           IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<Guid> Register(string username, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), username, email, hashedPassword);

            await _userRepository.Add(user);

            return user.Id;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _userRepository.Get();
        }

        public async Task<string> Login(string email, string password)
        {
            var user  = await _userRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
