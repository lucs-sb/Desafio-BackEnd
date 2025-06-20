using System.Text.Json.Serialization;

namespace MotoHub.API.Models.Rental;

public class CreateRentalModel
{
    [JsonPropertyName("identificador")]
    public string? Identifier { get; set; }

    [JsonPropertyName("data_inicio")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("data_termino")]
    public DateTime EndDate { get; set; }

    [JsonPropertyName("data_previsao_termino")]
    public DateTime ExpectedEndDate { get; set; }

    [JsonPropertyName("moto_id")]
    public string? MotorcycleIdentifier { get; set; }

    [JsonPropertyName("entregador_id")]
    public string? DeliveryManIdentifier { get; set; }

    [JsonPropertyName("plano")]
    public int? Plan { get; set; }
}
