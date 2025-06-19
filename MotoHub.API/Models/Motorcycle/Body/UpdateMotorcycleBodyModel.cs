using System.Text.Json.Serialization;

namespace MotoHub.API.Models.Motorcycle.Body;

public class UpdateMotorcycleBodyModel
{
    [JsonPropertyName("placa")]
    public string? LicensePlate { get; set; }
}
