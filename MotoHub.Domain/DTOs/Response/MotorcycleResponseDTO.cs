using System.Text.Json.Serialization;

namespace MotoHub.Domain.DTOs.Response;

public class MotorcycleResponseDTO
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
