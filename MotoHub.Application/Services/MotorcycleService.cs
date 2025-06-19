using Mapster;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Services;

public class MotorcycleService : IMotorcycleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMotorcycleRepository _motorcycleRepository;

    public MotorcycleService(IUnitOfWork unitOfWork, IMotorcycleRepository motorcycleRepository)
    {
        _unitOfWork = unitOfWork;
        _motorcycleRepository = motorcycleRepository;
    }

    public async Task CreateAsync(MotorcycleDTO motorcycleDTO)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            Motorcycle? motorcycle = await _motorcycleRepository.GetByIdentifierAsync(motorcycleDTO.Identifier);
            
            if (motorcycle != null)
                throw new Exception("Já existe uma moto com este identificador.");

            motorcycle = motorcycleDTO.Adapt<Motorcycle>();

            await _motorcycleRepository.AddAsync(motorcycle);

            await _unitOfWork.CommitAsync();

            //publicar quando uma moto do ano de 2024 for criada
        }
        catch
        {
            await _unitOfWork.RollbackAsync();

            throw;
        }
    }

    public async Task<MotorcycleResponseDTO> GetByIdentifierAsync(string identifier)
    {
        Motorcycle motorcycle = await _motorcycleRepository.GetByIdentifierAsync(identifier) ?? throw new Exception();

        return motorcycle.Adapt<MotorcycleResponseDTO>();
    }

    public async Task<List<MotorcycleResponseDTO>> GetAllOrByLicensePlateAsync(string? licensePlate)
    {
        List<Motorcycle> motorcycles = await _motorcycleRepository.GetAllOrByLicensePlateAsync(licensePlate);

        return motorcycles.Adapt<List<MotorcycleResponseDTO>>();
    }

    public async Task UpdateLicensePlateByIdentifierAsync(MotorcycleDTO motorcycleDTO)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            Motorcycle motorcycle = await _motorcycleRepository.GetByIdentifierAsync(motorcycleDTO.Identifier) ?? throw new Exception();

            motorcycle.LicensePlate = motorcycleDTO.LicensePlate;

            _motorcycleRepository.Update(motorcycle);

            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();

            throw;
        }
    }

    public async Task DeleteByIdentifierAsync(string identifier)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            Motorcycle motorcycle = await _motorcycleRepository.GetByIdentifierAsync(identifier) ?? throw new Exception();

            _motorcycleRepository.Remove(motorcycle);

            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();

            throw;
        }
    }
}
