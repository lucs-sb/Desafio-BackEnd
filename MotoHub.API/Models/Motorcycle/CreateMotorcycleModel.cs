namespace MotoHub.API.Models.Motorcycle;

public class CreateMotorcycleModel
{
    public string? Identifier { get; set; }
    public string? LicensePlate { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
}
