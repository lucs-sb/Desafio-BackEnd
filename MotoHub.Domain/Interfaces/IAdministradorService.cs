using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;

namespace MotoHub.Domain.Interfaces;

public interface IAdministradorService
{
    Task CreateAsync(AdministradorDTO administradorDTO);

    Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO);
}
