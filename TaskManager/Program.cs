using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Services;
using TaskManager.DataAccess;
using TaskManager.Domain.Abstractions;
using TaskManager.DataAccess.Repositories;
using UserAuthentication.Domain.Abstaraction;
using UserAuthentication.Domain.Abstractions;
using UserAuthentication.Application.Services;
using UserAuthentication.Inafrastructure;

namespace TaskManager
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

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

            builder.Services.AddScoped<IJwtProvider, JwtProvider>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();


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
