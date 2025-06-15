using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;

namespace MotoHub.Domain.Interfaces;

public interface IMotorcycleService
{
    Task CreateAsync(MotorcycleDTO motorcycleDTO);
    Task<Motorcycle?> GetByIdentifierAsync(string identifier);
    Task UpdateAsync(MotorcycleDTO motorcycleDTO);
    Task DeleteByIdentifierAsync(string identifier);
}
