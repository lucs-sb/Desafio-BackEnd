using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace MotoHub.API.Models.Rental;

public class GetRentalByIdentifierModel
{
    [FromRoute(Name = "id")]
    public string? Identifier { get; set; }
}
