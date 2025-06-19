using Microsoft.AspNetCore.Mvc;

namespace MotoHub.API.Models.Motorcycle;

public class GetMotorcycleByIdentifierModel
{
    [FromRoute(Name = "id")]
    public string? Identifier { get; set; }
}
