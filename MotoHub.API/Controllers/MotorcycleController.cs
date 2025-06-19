using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoHub.API.Models.Motorcycle;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Interfaces;

namespace MotoHub.API.Controllers
{
    [ApiController]
    [Route("motos")]
    [Authorize]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleService _motorcycleService;

        public MotorcycleController(IMotorcycleService MotorcycleService)
        {
            _motorcycleService = MotorcycleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateMotorcycleModel createMotorcycleModel)
        {
            MotorcycleDTO motorcycleDTO = createMotorcycleModel.Adapt<MotorcycleDTO>();
            await _motorcycleService.CreateAsync(motorcycleDTO);
            return Accepted();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrByLicensePlateAsync([FromQuery] string? licensePlate)
        {
            List<MotorcycleResponseDTO> motorcyclesResponseDTO = await _motorcycleService.GetAllOrByLicensePlateAsync(licensePlate);
            return Ok(motorcyclesResponseDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdentifierAsync(GetMotorcycleByIdentifierModel getMotorcycleByIdentifierModel)
        {
            MotorcycleResponseDTO motorcycleResponseDTO = await _motorcycleService.GetByIdentifierAsync(getMotorcycleByIdentifierModel.Identifier!);
            return Ok(motorcycleResponseDTO);
        }

        [HttpPut("{id}/placa")]
        public async Task<IActionResult> UpdateLicensePlateByIdentifierAsync(UpdateMotorcycleModel updateMotorcycleModel)
        {
            MotorcycleDTO motorcycleDTO = updateMotorcycleModel.Adapt<MotorcycleDTO>();
            await _motorcycleService.UpdateLicensePlateByIdentifierAsync(motorcycleDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdentifierAsync([FromRoute] string id)
        {
            await _motorcycleService.DeleteByIdentifierAsync(id);
            return Ok();
        }
    }
}
