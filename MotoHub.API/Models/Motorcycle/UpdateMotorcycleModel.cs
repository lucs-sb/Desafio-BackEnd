using Microsoft.AspNetCore.Mvc;
using MotoHub.API.Models.Motorcycle.Body;
using System.Text.Json.Serialization;

namespace MotoHub.API.Models.Motorcycle;

public class UpdateMotorcycleModel
{
    [FromRoute(Name = "id")]
    public string? Identifier { get; set; }

    [FromBody]
    public UpdateMotorcycleBodyModel? Body { get; set; }
}
