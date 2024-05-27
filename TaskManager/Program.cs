using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Services;
using TaskManager.DataAccess;
using TaskManager.DataAccess.Repositories;

namespace TaskManager
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddScoped<TaskDbContext>();
            builder.Services.AddDbContext<TaskManagerDbContext>(
                options =>
                {
                    options.UseNpgsql(builder
                        .Configuration
                        .GetConnectionString(nameof(TaskManagerDbContext)));
                });

            builder.Services.AddScoped<ITasksService, TasksService>();
            builder.Services.AddScoped<ITasksRepository, TasksRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
