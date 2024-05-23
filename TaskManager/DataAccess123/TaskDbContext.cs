using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.DataAccess
{
    public class TaskDbContext: DbContext
    {

        private readonly IConfiguration _configuration;

        public TaskDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Tasks> TaskSet => Set<Tasks>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("TaskDb"));
        }
    }
}
