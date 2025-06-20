using System.Text.Json.Serialization;

namespace MotoHub.API.Models.DeliveryMan;

public class UpdateDeliveryManModel
{
    [JsonPropertyName("imagem_cnh")]
    public string? DriverLicenseImage { get; set; }
}
