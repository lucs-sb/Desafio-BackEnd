using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;

namespace MotoHub.Domain.Interfaces;

public interface IMotorcycleService
{
    Task CreateAsync(MotorcycleDTO motorcycleDTO);
    Task<MotorcycleResponseDTO> GetByIdentifierAsync(string identifier);
    Task<List<MotorcycleResponseDTO>> GetAllOrByLicensePlateAsync(string? licensePlate);
    Task UpdateLicensePlateByIdentifierAsync(MotorcycleDTO motorcycleDTO);
    Task DeleteByIdentifierAsync(string identifier);
}
