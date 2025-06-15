using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories;

namespace MotoHub.Application.Services;

public class MotorcycleService : IMotorcycleService
{
    private readonly IMotorcycleRepository _motorcycleRepository;

    public MotorcycleService(IMotorcycleRepository motorcycleRepository)
    {
        _motorcycleRepository = motorcycleRepository;
    }

    public Task CreateAsync(MotorcycleDTO motorcycleDTO)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdentifierAsync(string identifier)
    {
        throw new NotImplementedException();
    }

    public Task<Motorcycle?> GetByIdentifierAsync(string identifier)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(MotorcycleDTO motorcycleDTO)
    {
        throw new NotImplementedException();
    }
}
