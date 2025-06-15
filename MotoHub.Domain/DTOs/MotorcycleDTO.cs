namespace MotoHub.Domain.DTOs;

public record MotorcycleDTO (string Identifier, 
    string LicensePlate, 
    string Model, 
    string Year)
{
}
