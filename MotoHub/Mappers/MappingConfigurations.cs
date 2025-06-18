namespace MotoHub.API.Mappers;

public static class MappingConfigurations
{
    public static IServiceCollection RegisterMaps(this IServiceCollection services)
    {
        services.RegisterAdministradorMaps();

        return services;
    }
}
