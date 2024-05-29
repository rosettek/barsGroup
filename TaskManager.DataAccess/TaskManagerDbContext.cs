using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Configurathions;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess
{
    public class TaskManagerDbContext: DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options): base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        //public DbSet<UserEntity> Users { get; set; }
    }
}
