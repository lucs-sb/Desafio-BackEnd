using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoHub.API.Models.Auth;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Interfaces;

namespace MotoHub.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
    {
        LoginDTO loginDTO = loginModel.Adapt<LoginDTO>();

        LoginResponseDTO loginResponseDTO = await _authService.LoginAsync(loginDTO);

        return StatusCode(StatusCodes.Status200OK, loginResponseDTO);
    }
}
