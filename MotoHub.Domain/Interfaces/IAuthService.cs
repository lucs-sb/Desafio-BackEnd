using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;

namespace MotoHub.Domain.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO);
}
