using Mapster;
using MotoHub.API.Models;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;

namespace MotoHub.API.Mappers;

public static class AdministradorMappingConfigurations
{
    public static void RegisterAdministradorMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<CreateAdministradorModel, AdministradorDTO>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.Password, src => src.Password);

        TypeAdapterConfig<AdministradorDTO, Administrador>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.Password, src => src.Password);
    }
}
