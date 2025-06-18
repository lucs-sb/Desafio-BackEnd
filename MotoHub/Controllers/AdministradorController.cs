using Mapster;
using Microsoft.AspNetCore.Mvc;
using MotoHub.API.Models;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.Interfaces;

namespace MotoHub.API.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorService _administradorService;

        public AdministradorController(IAdministradorService administradorService)
        {
            _administradorService = administradorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAdministradorModel createAdministradorModel)
        {
            AdministradorDTO administradorDTO = createAdministradorModel.Adapt<AdministradorDTO>();

            await _administradorService.CreateAsync(administradorDTO);

            return Accepted();
        }
    }
}