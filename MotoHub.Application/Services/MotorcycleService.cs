using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Services;

public class MotorcycleService : IMotorcycleService
{
    private readonly IUnitOfWork _unitOfWork;

    public MotorcycleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
