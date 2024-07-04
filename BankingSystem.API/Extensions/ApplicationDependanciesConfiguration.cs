using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Repositories.Implementations;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Implementations;
using BankingSystem.Infrastructure.Services.Interfaces;
using BankingSystem.ManagementService.Consumers;
using BankingSystem.MessageBrokers.Shared;
using Hangfire;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace BankingSystem.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static partial class ApplicationDependanciesConfiguration
    {
        public static IServiceCollection ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<BankingSystemDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHangfire(x =>
            {
                x.UseSqlServerStorage(builder.Configuration.GetConnectionString("Database"));
            });
            builder.Services.AddHangfireServer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthorization();
            builder.Services.AddCors();
            builder.Services.AddControllers()
                            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICardTypeServiceInfrastructure, CardTypeServiceInfrastructure>()
                .AddScoped<ICardServiceInfrastructure, CardServiceInfrastructure>()
                .AddScoped<IPassportServiceInfrastructure, PassportServiceInfrastructure>()
                .AddScoped<IPassportRepository, PassportRepository>()
                .AddScoped<IBankServiceInfrastructure, BankServiceInfrastructure>()
                .AddScoped<IBankRepository, BankRepository>()
                .AddScoped<IAccountTypeServiceInfrastructure, AccountTypeServiceInfrastructure>()
                .AddScoped<IAccountTypeRepository, AccountTypeRepository>()
                .AddScoped<IClientAccountServiceInfrastructure, ClientAccountServiceInfrastructure>()
                .AddScoped<IClientAccountRepository, ClientAccountRepository>()
                .AddScoped<IPassportServiceInfrastructure, PassportServiceInfrastructure>()
                .AddScoped<IPassportRepository, PassportRepository>()
                .AddScoped<IBankServiceInfrastructure, BankServiceInfrastructure>()
                .AddScoped<IBankRepository, BankRepository>()
                .AddScoped<IAccountTypeServiceInfrastructure, AccountTypeServiceInfrastructure>()
                .AddScoped<IAccountTypeRepository, AccountTypeRepository>()
                .AddScoped<IClientAccountServiceInfrastructure, ClientAccountServiceInfrastructure>()
                .AddScoped<IClientAccountRepository, ClientAccountRepository>()
                .AddScoped<ICardTypeRepository, CardTypeRepository>()
                .AddScoped<ICardRepository, CardRepository>()
                .AddScoped<IExpenseCalculatorInfrastructure, ExpenseCalculatorInfrastructure>()
                .AddScoped<IStripeServiceInfrastructure, StripeServiceInfrastructure>()
                .AddScoped<ITransactionTypeRepository, TransactionTypeRepository>()
                .AddScoped<ITransactionTypeServiceInfrastructure, TransactionTypeServiceInfrastructure>()
                .AddScoped<ITransactionRepository, TransactionRepository>()
                .AddScoped<ITransactionServiceInfrastructure, TransactionServiceInfrastructure>()
                .AddScoped<IClientExpenseRepository, ClientExpenseRepository>()
                .AddScoped<IClientExpenseServiceInfrastructure, ClientExpenseServiceInfrastructure>()
                .AddAutoMapper(Assembly.GetExecutingAssembly());

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
        /// <summary>
        /// Configures MassTransit and Consumers
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<RabbitMQConfigurations>().Bind(configuration.GetSection("RabbitMQ"));

            services.AddMassTransit(x =>
            {
                x.AddConsumer<UserDeletedConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    var options = context.GetRequiredService<IOptions<RabbitMQConfigurations>>().Value;

                    cfg.Host(options.Host, h =>
                    {
                        h.Username(options.Username);
                        h.Password(options.Password);
                    });

                    cfg.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(true));

                    cfg.ReceiveEndpoint("BankingSystem.DeleteUser", c =>
                    {
                        c.ConfigureConsumer<UserDeletedConsumer>(context);
                    });

                });
            });

        }

    }
}
