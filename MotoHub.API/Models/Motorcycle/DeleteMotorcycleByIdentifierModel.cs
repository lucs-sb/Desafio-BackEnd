using Microsoft.AspNetCore.Mvc;

namespace MotoHub.API.Models.Motorcycle;

public class DeleteMotorcycleByIdentifierModel
{
    [FromRoute]
    public string? Identifier { get; set; }
}
