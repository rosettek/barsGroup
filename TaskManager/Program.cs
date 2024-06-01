using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Services;
using TaskManager.DataAccess;
using TaskManager.Domain.Abstractions;
using TaskManager.DataAccess.Repositories;
using UserAuthentication.Domain.Abstaraction;
using UserAuthentication.Domain.Abstractions;
using UserAuthentication.Application.Services;
using UserAuthentication.Inafrastructure;
using Microsoft.AspNetCore.Builder;
using TaskManager.Extentions;
using Microsoft.Extensions.Options;


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


            builder.Services.AddApiAuthentication(builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>());



            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
