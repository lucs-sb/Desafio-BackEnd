namespace MotoHub.Domain.DTOs.Response;

public record MotorcycleResponseDTO(string Identifier,
    string LicensePlate,
    string Model,
    string Year)
{
}
