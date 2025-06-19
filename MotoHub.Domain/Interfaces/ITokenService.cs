using MotoHub.Domain.DTOs.Response;

namespace MotoHub.Domain.Interfaces;

public interface ITokenService
{
    Task<LoginResponseDTO> GenerateToken(string id, bool isAdmin);
}
