using System.Text.Json.Serialization;

namespace MotoHub.API.Models.Rental.Body;

public class UpdateRentalBodyModel
{
    [JsonPropertyName("data_devolucao")]
    public DateTime ReturnDate { get; set; }
}
