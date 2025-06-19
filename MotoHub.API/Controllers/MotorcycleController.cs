using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoHub.API.Models.Motorcycle;
using MotoHub.Domain.DTOs;
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
    }
}
