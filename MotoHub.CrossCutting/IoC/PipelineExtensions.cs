using Microsoft.Extensions.DependencyInjection;
using MotoHub.Application.Services;
using MotoHub.Domain.Interfaces;

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
}
