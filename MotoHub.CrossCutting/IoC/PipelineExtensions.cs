using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MotoHub.Application.Services;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Interfaces.Repositories.Base;
using MotoHub.Domain.Settings;
using MotoHub.Infrastructure.Auth;
using MotoHub.Infrastructure.Repositories;
using MotoHub.Infrastructure.Repositories.Base;

namespace MotoHub.CrossCutting.IoC;

public static class PipelineExtensions
{
    public static void AddApplicationDI(this IServiceCollection services)
    {
        services.AddScoped<IAdministratorService, AdministratorService>();
        services.AddScoped<IDeliveryManService, DeliveryManService>();
        services.AddScoped<IMotorcycleService, MotorcycleService>();
        services.AddScoped<IRentalService, RentalService>();
        services.AddScoped<IAuthService, AuthService>();
    }

    public static void AddAInfrastructureDI(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();

        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));
    }

    public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MotoHubDatabaseSettings>(configuration.GetSection("MotoHubDatabase"));
        services.Configure<AuthSettings>(configuration.GetSection("AuthSettings"));
    }
}
