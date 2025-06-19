using Mapster;
using MotoHub.API.Models.Motorcycle;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;

namespace MotoHub.API.Mappers
{
    public static class MotorcycleMappingConfigurations
    {
        public static void RegisterMotorcycleMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<CreateMotorcycleModel, MotorcycleDTO>
                .NewConfig()
                .Map(dest => dest.Identifier, src => src.Identifier)
                .Map(dest => dest.LicensePlate, src => src.LicensePlate)
                .Map(dest => dest.Model, src => src.Model)
                .Map(dest => dest.Year, src => src.Year);

            TypeAdapterConfig<MotorcycleDTO, Motorcycle>
                .NewConfig()
                .Map(dest => dest.Identifier, src => src.Identifier)
                .Map(dest => dest.LicensePlate, src => src.LicensePlate)
                .Map(dest => dest.Model, src => src.Model)
                .Map(dest => dest.Year, src => src.Year);

            TypeAdapterConfig<Motorcycle, MotorcycleResponseDTO>
                .NewConfig()
                .Map(dest => dest.Identifier, src => src.Identifier)
                .Map(dest => dest.LicensePlate, src => src.LicensePlate)
                .Map(dest => dest.Model, src => src.Model)
                .Map(dest => dest.Year, src => src.Year);

            TypeAdapterConfig<Motorcycle, MotorcycleResponseDTO>
                .NewConfig()
                .Map(dest => dest.Identifier, src => src.Identifier)
                .Map(dest => dest.LicensePlate, src => src.LicensePlate)
                .Map(dest => dest.Model, src => src.Model)
                .Map(dest => dest.Year, src => src.Year);

            TypeAdapterConfig<UpdateMotorcycleModel, MotorcycleDTO>
                .NewConfig()
                .Map(dest => dest.LicensePlate, src => src.Body!.LicensePlate);
        }
    }
}
