using Serilog;

namespace BankingSystem.API.Extensions
{
    public static class ApplicationDependanciesConfiguration
    {
        public static IServiceCollection ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            builder.Services.AddCors();

            return builder.Services;
        }
        public static IServiceCollection AddLogger(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName();
            });

            return builder.Services;
        }

    }
}
