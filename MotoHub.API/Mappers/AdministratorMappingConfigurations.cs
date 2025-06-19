using Mapster;
using MotoHub.API.Models.Administrator;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;

namespace MotoHub.API.Mappers;

public static class AdministratorMappingConfigurations
{
    public static void RegisterAdministradorMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<CreateAdministratorModel, AdministratorDTO>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.Password, src => src.Password);

        TypeAdapterConfig<AdministratorDTO, Administrator>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.Password, src => src.Password);

        TypeAdapterConfig<LoginModel, LoginDTO>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.Password, src => src.Password);

        TypeAdapterConfig<(string, DateTime), LoginResponseDTO>
            .NewConfig()
            .Map(dest => dest.access_token, src => src.Item1)
            .Map(dest => dest.expiration, src => src.Item2);
    }
}
