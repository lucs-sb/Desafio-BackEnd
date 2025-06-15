using MotoHub.Domain.Entities;

namespace MotoHub.Domain.Interfaces.Repositories;

public interface IMotorcycleRepository
{
    Task CreateAsync(Motorcycle motorcycle);
    Task<Motorcycle?> GetByIdentifierAsync(string identifier);
    Task UpdateAsync(Motorcycle motorcycle);
    Task DeleteByIdentifierAsync(string identifier);
}
