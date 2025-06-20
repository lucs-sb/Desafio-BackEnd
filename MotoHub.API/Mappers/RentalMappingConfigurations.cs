using Mapster;
using MotoHub.API.Models.Rental;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;

namespace MotoHub.API.Mappers;

public static class RentalMappingConfigurations
{
    public static void RegisterRentalMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<CreateRentalModel, RentalDTO>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.StartDate, src => src.StartDate)
            .Map(dest => dest.EndDate, src => src.EndDate)
            .Map(dest => dest.ExpectedEndDate, src => src.ExpectedEndDate)
            .Map(dest => dest.MotorcycleIdentifier, src => src.MotorcycleIdentifier)
            .Map(dest => dest.DeliveryManIdentifier, src => src.DeliveryManIdentifier)
            .Map(dest => dest.Plan, src => src.Plan);

        TypeAdapterConfig<RentalDTO, Rental>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.StartDate, src => src.StartDate)
            .Map(dest => dest.EndDate, src => src.EndDate)
            .Map(dest => dest.ExpectedEndDate, src => src.ExpectedEndDate)
            .Map(dest => dest.MotorcycleIdentifier, src => src.MotorcycleIdentifier)
            .Map(dest => dest.DeliveryManIdentifier, src => src.DeliveryManIdentifier)
            .Map(dest => dest.ReturnDate, src => src.EndDate)
            .Map(dest => dest.Plan, src => src.Plan);

        TypeAdapterConfig<Rental, RentalResponseDTO>
            .NewConfig()
            .Map(dest => dest.Identifier, src => src.Identifier)
            .Map(dest => dest.StartDate, src => src.StartDate)
            .Map(dest => dest.EndDate, src => src.EndDate)
            .Map(dest => dest.ExpectedEndDate, src => src.ExpectedEndDate)
            .Map(dest => dest.MotorcycleIdentifier, src => src.MotorcycleIdentifier)
            .Map(dest => dest.DeliveryManIdentifier, src => src.DeliveryManIdentifier)
            .Map(dest => dest.ReturnDate, src => src.ReturnDate)
            .Map(dest => dest.Value, src => src.Value)
            .Map(dest => dest.Plan, src => src.Plan);
    }
}
