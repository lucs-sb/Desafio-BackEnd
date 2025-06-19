using Mapster;
using MotoHub.API.Models.Auth;
using MotoHub.Domain.DTOs;

namespace MotoHub.API.Mappers;

public static class AuthMappingConfigurations
{
    public static void RegisterAuthMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<LoginModel, LoginDTO>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.Password, src => src.Password);
    }
}