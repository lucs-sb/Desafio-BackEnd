using System.Text.Json.Serialization;

namespace MotoHub.API.Models.Motorcycle;

public class CreateMotorcycleModel
{
    [JsonPropertyName("identificador")]
    public string? Identifier { get; set; }

    [JsonPropertyName("placa")]
    public string? LicensePlate { get; set; }

    [JsonPropertyName("modelo")]
    public string? Model { get; set; }

    [JsonPropertyName("ano")]
    public int? Year { get; set; }
}
