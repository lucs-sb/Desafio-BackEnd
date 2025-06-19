using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Domain.Interfaces.Repositories;

public interface IMotorcycleRepository : IRepository<Motorcycle>
{
    Task<List<Motorcycle>> GetAllOrByLicensePlateAsync(string? licensePlate);
}
