using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoHub.API.Models.Administrador;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Interfaces;

namespace MotoHub.API.Controllers;

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
    [AllowAnonymous]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAdministradorModel createAdministradorModel)
    {
        AdministradorDTO administradorDTO = createAdministradorModel.Adapt<AdministradorDTO>();

        await _administradorService.CreateAsync(administradorDTO);

        return Accepted();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
    {
        LoginDTO loginDTO = loginModel.Adapt<LoginDTO>();

        LoginResponseDTO loginResponseDTO = await _administradorService.LoginAsync(loginDTO);

        return StatusCode(StatusCodes.Status200OK, loginResponseDTO);
    }
}