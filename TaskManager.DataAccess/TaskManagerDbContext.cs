﻿using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess
{
    public class TaskManagerDbContext: DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options): base(options) 
        { 
        }

        public DbSet<TaskEntity> Tasks { get; set;}
    }
}
