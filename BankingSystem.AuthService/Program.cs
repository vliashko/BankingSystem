using BankingSystem.AuthService.AuthService.API.Extensions;
using BankingSystem.AuthService.AuthService.API.Middlewares;

namespace BankingSystem.AuthService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Configuration.AddEnvironmentVariables();

            builder.ConfigureAuthServices();
            builder.AddAuthLogger();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors(options =>
            {
                options.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
