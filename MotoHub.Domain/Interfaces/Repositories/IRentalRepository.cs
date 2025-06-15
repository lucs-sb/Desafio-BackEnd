using MotoHub.Domain.Entities;

namespace MotoHub.Domain.Interfaces.Repositories;

public interface IRentalRepository
{
    Task CreateAsync(Rental rental);
    Task<Rental?> GetByIdAsync(int id);
    Task UpdateAsync(Rental rental);
    Task DeleteAsync(int id);
}
