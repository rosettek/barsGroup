using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Entities;
using UserAuthentication.Domain.Models;
using UserAuthentication.Domain.Abstractions;

namespace TaskManager.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagerDbContext _context;

        public UserRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Get()
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntity.Select(b => User.Create(
                b.Id,
                b.Name,
                b.Email,
                b.PasswordHash
                )).ToList();

            return users;
        }

        public async Task<Guid> Add(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
            //.Where(u => u.Email == email)
            //.ToListAsync();

            //var users = userEntity.Select(b => User.Create(
            //    b.Id,
            //    b.Name,
            //    b.Email,
            //    b.PasswordHash
            //    )).ToList();

            User user = User.Create(userEntity.Id,
                                    userEntity.Name,
                                    userEntity.Email,
                                    userEntity.PasswordHash);
            return user;
        }
    }
}
