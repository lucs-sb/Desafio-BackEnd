using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoHub.API.Models.DeliveryMan;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.Interfaces;

namespace MotoHub.API.Controllers;

[ApiController]
[Route("entregadores")]
public class DeliveryManController : ControllerBase
{
    private readonly IDeliveryManService _deliveryManService;

    public DeliveryManController(IDeliveryManService deliveryManService)
    {
        _deliveryManService = deliveryManService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAsync([FromBody] CreateDeliveryManModel createDeliveryManModel)
    {
        DeliveryManDTO deliveryManDTO = createDeliveryManModel.Adapt<DeliveryManDTO>();

        await _deliveryManService.CreateAsync(deliveryManDTO);

        return Created();
    }

    [HttpPost("{id}/cnh")]
    public async Task<IActionResult> UpdateLicensePlateByIdentifierAsync([FromRoute(Name = "id")] string identifier, [FromBody] UpdateDeliveryManModel updateDeliveryManModel)
    {
        await _deliveryManService.UpdateAsync(identifier, updateDeliveryManModel.DriverLicenseImage!);
        return Created();
    }
}
