using Mapster;
using MotoHub.API.Models.DeliveryMan;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;

namespace MotoHub.API.Mappers;

public static class DeliveryManMappingConfigurations
{
    public static void RegisterDeliveryManMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<CreateDeliveryManModel, DeliveryManDTO>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.DriverLicenseNumber, src => src.DriverLicenseNumber)
            .Map(dest => dest.DriverLicenseType, src => src.DriverLicenseType)
            .Map(dest => dest.TaxNumber, src => src.TaxNumber)
            .Map(dest => dest.DateOfBirth, src => src.DateOfBirth);

        TypeAdapterConfig<DeliveryManDTO, DeliveryMan>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.DriverLicenseNumber, src => src.DriverLicenseNumber)
            .Map(dest => dest.DriverLicenseType, src => src.DriverLicenseType)
            .Map(dest => dest.TaxNumber, src => src.TaxNumber)
            .Map(dest => dest.DateOfBirth, src => src.DateOfBirth);
    }
}
