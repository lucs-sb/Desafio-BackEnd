using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MotoHub.Application.Services;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Settings;
using MotoHub.Infrastructure.Auth;
using MotoHub.Infrastructure.Repositories;

namespace MotoHub.CrossCutting.IoC;

public static class PipelineExtensions
{
    public static void AddApplicationDI(this IServiceCollection services)
    {
        services.AddScoped<IAdministradorService, AdministradorService>();
        services.AddScoped<IDeliveryManService, DeliveryManService>();
        services.AddScoped<IMotorcycleService, MotorcycleService>();
        services.AddScoped<IRentalService, RentalService>();
    }

    public static void AddAInfrastructureDI(this IServiceCollection services)
    {
        services.AddScoped<IAdministradorRepository, AdministradorRepository>();
        services.AddScoped<IDeliveryManRepository, DeliveryManRepository>();
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();

        services.AddScoped<ITokenService, TokenService>();
    }

    public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MotoHubDatabaseSettings>(configuration.GetSection("MotoHubDatabase"));
        services.Configure<AuthSettings>(configuration.GetSection("AuthConfiguration"));
    }

    public static void AddAuthenticationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(authOptions =>
        {
            authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["AuthConfiguration:SecretKey"]!)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
}
