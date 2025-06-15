using MotoHub.Domain.Entities.Abstractions;

namespace MotoHub.Domain.Entities;

public class DeliveryMan : User
{
    public string? Name { get; set; }
    public string? DriverLicenseNumber { get; set; }
    public string? DriverLicenseType { get; set; }
    public string? TaxNumber { get; set; }
    public string? DateOfBirth { get; set; }
}
