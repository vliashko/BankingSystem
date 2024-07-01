using BankingSystem.MessageBrokers.Shared;
using BankingSystem.NotificationService.NotificationService.API.Configurations;
using BankingSystem.NotificationService.NotificationService.API.Consumers;
using BankingSystem.NotificationService.NotificationService.Infrastructure.Services;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using MassTransit;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace BankingSystem.NotificationService.NotificationService.API.Extensions
{
   
    public static class ApplicationDependenciesConfiguration
    {
        /// <summary>
        /// Add all needed services that will be injected in different parts of the app
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailSenderService, EmailSenderService>();
        }
        /// <summary>
        /// Adds all needed configurations for mapping object
        /// </summary>
        /// <param name="services"></param>
        public static void AddMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserMappingProfile));
        }

        /// <summary>
        /// Configures services to allow the application to use jwt authorization and authentication 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        public static void ConfigureKeycloakAuth(this WebApplicationBuilder builder, IConfiguration configuration) 
        {
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
        }
        /// <summary>
        /// configures the swagger ui for the application
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureSwaggerGen(this WebApplicationBuilder builder) 
        {
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
        }

        /// <summary>
        /// configures the cross origin ressource sharing of the app so that third-party app might access the ressource of the given api
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureCrossOriginRessourceSharing(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
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
                x.AddConsumer<UserRegisteredConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    var options = context.GetRequiredService<IOptions<RabbitMQConfigurations>>().Value;

                    cfg.Host(options.Host, h =>
                    {
                        h.Username(options.Username);
                        h.Password(options.Password);
                    });

                    cfg.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(true));

                    cfg.ReceiveEndpoint("BankingSystem.Registration", c =>
                    {
                        c.ConfigureConsumer<UserRegisteredConsumer>(context);
                    });

                });
            });
             
        }
    }
}
