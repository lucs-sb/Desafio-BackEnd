namespace MotoHub.API.Models.DeliveryMan;

public class CreateDeliveryManModel
{
    public string? Name { get; set; }
    public string? DriverLicenseNumber { get; set; }
    public string? DriverLicenseType { get; set; }
    public string? TaxNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}
