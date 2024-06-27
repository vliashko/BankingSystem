using BankingSystem.AuthService.AuthService.Infrastructure.Services.Implementations;
using BankingSystem.AuthService.AuthService.Infrastructure.Services.Interfaces;
using BankingSystem.AuthService.BankingSystem.DataAccess.Data;
using BankingSystem.AuthService.BankingSystem.DataAccess.Repositories.Implementations;
using BankingSystem.AuthService.BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.MessageBrokers.Shared;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace BankingSystem.AuthService.AuthService.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static partial class ApplicationDependanciesConfiguration
    {
        public static IServiceCollection ConfigureAuthServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
            builder.Services.Configure<RabbitMQConfigurations>(builder.Configuration.GetSection("RabbitMQ"));

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
            builder.Services.AddAuthorization();
            builder.Services.AddCors();
            builder.Services.AddControllers()
                            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserServiceInfrastructure, UserServiceInfrastructure>()
                            .AddScoped<IUserRepository, UserRepository>()
                            .AddAutoMapper(Assembly.GetExecutingAssembly());
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

            return builder.Services;
        }
        public static IServiceCollection AddAuthLogger(this WebApplicationBuilder builder)
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
        /// Adds massTransit and RabbitMQ configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(_busRegistration =>
            {
                _busRegistration.UsingRabbitMq((context, cfg) =>
                {
                    var options = context.GetRequiredService<IOptions<RabbitMQConfigurations>>();

                    cfg.Host(options.Value.Host, h =>
                    {
                        h.Username(options.Value.Username);
                        h.Password(options.Value.Password);
                    });
                });
            });

            return services;
        }
    }
}
