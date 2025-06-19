using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;

namespace MotoHub.Domain.Interfaces;

public interface IAdministratorService
{
    Task CreateAsync(AdministratorDTO administradorDTO);

    Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO);
}
