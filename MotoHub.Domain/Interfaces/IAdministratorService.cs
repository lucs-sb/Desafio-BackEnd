using MotoHub.Domain.DTOs;

namespace MotoHub.Domain.Interfaces;

public interface IAdministratorService
{
    Task CreateAsync(AdministratorDTO administradorDTO);
}
