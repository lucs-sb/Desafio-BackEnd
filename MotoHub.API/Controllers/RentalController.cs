using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoHub.API.Models.Rental;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Interfaces;

namespace MotoHub.API.Controllers
{
    [ApiController]
    [Route("locacao")]
    [Authorize(Roles = "Admin,DeliveryMan")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRentalModel createRentalModel)
        {
            RentalDTO rentalDTO = createRentalModel.Adapt<RentalDTO>();
            await _rentalService.CreateAsync(rentalDTO);
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdentifierAsync(GetRentalByIdentifierModel getRentalByIdentifierModel)
        {
            RentalResponseDTO rentalResponseDTO = await _rentalService.GetByIdAsync(getRentalByIdentifierModel.Identifier!);
            return Ok(rentalResponseDTO);
        }

        [HttpPut("{id}/devolucao")]
        public async Task<IActionResult> UpdateByIdentifierAsync(UpdateRentalModel updateRentalModel)
        {
            await _rentalService.UpdateAsync(updateRentalModel.Identifier!, updateRentalModel.Body!.ReturnDate);
            return Ok();
        }
    }
}
