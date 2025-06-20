namespace MotoHub.Domain.DTOs;

public record DeliveryManDTO (string Identifier, 
    string Password,
    string Name, 
    string DriverLicenseNumber, 
    string DriverLicenseType, 
    string TaxNumber, 
    DateTime DateOfBirth,
    string? DriverLicenseImage)
{
}
