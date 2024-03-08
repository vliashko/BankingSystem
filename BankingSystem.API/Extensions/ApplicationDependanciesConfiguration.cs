namespace BankingSystem.API.Extensions
{
    public static class ApplicationDependanciesConfiguration
    {
        public static IServiceCollection ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();
       
            return builder.Services;
        }
    }
}
