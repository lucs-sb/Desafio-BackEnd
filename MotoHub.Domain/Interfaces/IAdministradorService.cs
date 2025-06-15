using MotoHub.Domain.DTOs;

namespace MotoHub.Domain.Interfaces;

public interface IAdministradorService
{
    Task CreateAsync(AdministradorDTO administradorDTO);
}
