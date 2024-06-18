using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Repositories.Implementations;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Implementations;
using BankingSystem.Infrastructure.Services.Interfaces;
using Hangfire;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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

            builder.Services.AddKeycloakAuthentication(new KeycloakAuthenticationOptions()
            {
                AuthServerUrl = builder.Configuration["Keycloak:auth-server-url"]!,
                Realm = builder.Configuration["Keycloak:realm"]!,
                Resource = builder.Configuration["Keycloak:resource"]!,
                SslRequired = builder.Configuration["Keycloak:ssl-required"]!,
                VerifyTokenAudience = false,
            });
            builder.Services.AddKeycloakAuthorization(new KeycloakProtectionClientOptions()
            {
                AuthServerUrl = builder.Configuration["Keycloak:auth-server-url"]!,
                Realm = builder.Configuration["Keycloak:realm"]!,
                Resource = builder.Configuration["Keycloak:resource"]!,
                SslRequired = builder.Configuration["Keycloak:ssl-required"]!,
                VerifyTokenAudience = false,
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHangfire(x =>
            {
                x.UseSqlServerStorage(builder.Configuration.GetConnectionString("Database"));
            });
            builder.Services.AddHangfireServer();
            builder.Services.AddSwaggerGen(c =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Keycloak",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.OpenIdConnect,
                    OpenIdConnectUrl = new Uri($"{builder.Configuration["Keycloak:auth-server-url"]}realms/{builder.Configuration["Keycloak:realm"]}/.well-known/openid-configuration"),
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme,
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {securityScheme, Array.Empty<string>() }
                });
            });
            builder.Services.AddAuthorization();
            builder.Services.AddCors();
            builder.Services.AddControllers()
                            .AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserServiceInfrastructure, UserServiceInfrastructure>()
                .AddScoped<ICardTypeServiceInfrastructure, CardTypeServiceInfrastructure>()
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
                .AddScoped<IEmailSenderServiceInfrastructure, EmailSenderServiceInfrastrucutre>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserServiceInfrastructure, UserServiceInfrastructure>()
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

    }
}
