namespace MotoHub.Domain.DTOs;

public record DeliveryManDTO (string Identifier, string Name, 
    string DriverLicenseNumber, 
    string DriverLicenseType, 
    string TaxNumber, 
    DateTime DateOfBirth)
{
}
