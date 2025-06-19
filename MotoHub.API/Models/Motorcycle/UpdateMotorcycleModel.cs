using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace MotoHub.API.Models.Motorcycle;

public class UpdateMotorcycleModel
{
    [FromRoute]
    public string? Identifier { get; set; }

    [FromBody]
    [JsonPropertyName("placa")]
    public string? LicensePlate { get; set; }
}
