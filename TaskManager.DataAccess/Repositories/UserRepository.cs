//using Microsoft.EntityFrameworkCore;
//using TaskManager.DataAccess.Entities;
//using User.Domain.Models;

//namespace TaskManager.DataAccess.Repositories
//{
//    public class UserRepository
//    {
//        private readonly TaskManagerDbContext _context;

//        public UserRepository(TaskManagerDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<User>> Get()
//        {
//            var userEntity = await _context.Users
//                .AsNoTracking()
//                .ToListAsync();

//            var users = userEntity.Select(b => User.Create(
//                b.User_id,
//                b.Name,
//                b.Email,
//                b.PasswordHash
//                )).ToList();

//            return users;
//        }

//        public async Task<Guid> Add(User user)
//        {
//            var userEntity = new UserEntity
//            {
//                User_id = user.User_id,
//                Name = user.Name,
//                Email = user.Email,
//                PasswordHash = user.PasswordHash,
//            };

//            await _context.Users.AddAsync(userEntity);
//            await _context.SaveChangesAsync();

//            return userEntity.User_id;
//        }

//        public async Task<User> GetByEmail(string email)
//        {
//            var userEntity = await _context.Users
//                .AsNoTracking()
//                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

//            return _mapper.Map<User>(userEntity);
//        }
//    }
//}
