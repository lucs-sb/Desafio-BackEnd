using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Domain.Interfaces.Repositories;

public interface IRentalRepository : IRepository<Rental>
{
    Task<Rental?> GetByMotorcycleIdentifierAsync(string motorcycleIdentifier);
}
