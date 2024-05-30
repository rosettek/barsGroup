using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Entities;
using UserAuthentication.Domain.Models;

namespace TaskManager.DataAccess.Repositories
{
    public class UserRepository
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

        public async Task<List<User>> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .Where(u => u.Email == email)
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
    }
}
