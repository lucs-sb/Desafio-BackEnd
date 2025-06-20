using Microsoft.AspNetCore.Mvc;
using MotoHub.API.Models.Rental.Body;

namespace MotoHub.API.Models.Rental;

public class UpdateRentalModel
{
    [FromRoute(Name = "id")]
    public string? Identifier { get; set; }

    [FromBody]
    public UpdateRentalBodyModel? Body { get; set; }
}
