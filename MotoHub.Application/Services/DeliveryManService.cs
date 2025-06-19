using Mapster;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Services;

public class DeliveryManService : IDeliveryManService
{
    private readonly IUnitOfWork _unitOfWork;

    public DeliveryManService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(DeliveryManDTO deliveryManDTO)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            DeliveryMan deliveryMan = deliveryManDTO.Adapt<DeliveryMan>();

            //deliveryMan.Password = _passwordHasher.HashPassword(deliveryMan, deliveryManDTO.Password);

            await _unitOfWork.Repository<DeliveryMan>().AddAsync(deliveryMan);

            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();

            throw;
        }
    }
}
