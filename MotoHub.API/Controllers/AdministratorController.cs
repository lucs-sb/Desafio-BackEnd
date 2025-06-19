using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoHub.API.Models.Administrator;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.Interfaces;

namespace MotoHub.API.Controllers;

[ApiController]
[Route("admin")]
public class AdministratorController : ControllerBase
{
    private readonly IAdministratorService _administratorService;

    public AdministratorController(IAdministratorService administratorService)
    {
        _administratorService = administratorService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAdministratorModel createAdministratorModel)
    {
        AdministratorDTO administratorDTO = createAdministratorModel.Adapt<AdministratorDTO>();

        await _administratorService.CreateAsync(administratorDTO);

        return Accepted();
    }
}