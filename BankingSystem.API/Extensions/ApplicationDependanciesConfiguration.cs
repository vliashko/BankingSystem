using BankingSystem.BusinessLogic.Services.Implementantions;
using BankingSystem.BusinessLogic.Services.Interfaces;
using BankingSystem.DataAccess.Data;
using BankingSystem.Infrastructure.Services.Implementations;
using BankingSystem.Infrastructure.Services.Interfaces;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

namespace BankingSystem.API.Extensions
{
    public static class ApplicationDependanciesConfiguration
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
            builder.Services.AddControllers();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserServiceInfrastructure, UserServiceInfrastructure>();
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
