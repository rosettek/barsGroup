
using TaskManager.DataAccess;

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
            builder.Services.AddScoped<TaskDbContext>();

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
             using var dbContext = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
             dbContext.Database.EnsureCreatedAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
