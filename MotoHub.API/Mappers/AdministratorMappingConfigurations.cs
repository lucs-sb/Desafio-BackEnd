﻿using Mapster;
using MotoHub.API.Models.Administrator;
using MotoHub.Domain.DTOs;
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

        TypeAdapterConfig<AdministratorDTO, UserAuth>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.IsAdmin, src => true);
    }
}
