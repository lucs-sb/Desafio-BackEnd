using Microsoft.AspNetCore.Mvc;
using MotoHub.Domain.Interfaces;

namespace MotoHub.API.Controllers
{
    [ApiController]
    [Route("motos")]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleService _motorcycleService;

        public MotorcycleController(IMotorcycleService MotorcycleService)
        {
            _motorcycleService = MotorcycleService;
        }
    }
}
