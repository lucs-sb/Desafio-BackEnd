using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;

namespace MotoHub.Domain.Interfaces;

public interface ITokenService
{
    Task<LoginResponseDTO> GenerateToken(Administrador administrador);
}
