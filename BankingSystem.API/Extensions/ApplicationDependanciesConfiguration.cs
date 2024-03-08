namespace BankingSystem.API.Extensions
{
    public static class ApplicationDependanciesConfiguration
{
    public static IServiceCollection ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthorization();
        builder.Services.AddLogging(options =>
        {
            options.AddConsole();
            options.AddDebug();
        });
            builder.Services.AddCors();

        return builder.Services;
    }
}
}
