using System.Text.Json.Serialization;

namespace MotoHub.API.Models.DeliveryMan;

public class CreateDeliveryManModel
{
    [JsonPropertyName("identificador")]
    public string? Identifier { get; set; }

    [JsonPropertyName("nome")]
    public string? Name { get; set; }

    [JsonPropertyName("numero_cnh")]
    public string? DriverLicenseNumber { get; set; }

    [JsonPropertyName("tipo_cnh")]
    public string? DriverLicenseType { get; set; }

    [JsonPropertyName("cnpj")]
    public string? TaxNumber { get; set; }

    [JsonPropertyName("data_nascimento")]
    public DateTime DateOfBirth { get; set; }
}
