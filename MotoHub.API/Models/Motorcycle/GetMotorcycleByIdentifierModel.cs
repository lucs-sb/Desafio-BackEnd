using Microsoft.AspNetCore.Mvc;

namespace MotoHub.API.Models.Motorcycle;

public class GetMotorcycleByIdentifierModel
{
    [FromRoute]
    public string? Identifier { get; set; }
}
