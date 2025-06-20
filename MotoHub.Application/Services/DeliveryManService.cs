using Mapster;
using Microsoft.AspNetCore.Identity;
using MotoHub.Application.Resources;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Services;

public class DeliveryManService : IDeliveryManService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<UserAuth> _passwordHasher;

    public DeliveryManService(IUnitOfWork unitOfWork, IPasswordHasher<UserAuth> passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task CreateAsync(DeliveryManDTO deliveryManDTO)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            UserAuth? user = await _unitOfWork.Repository<UserAuth>().GetByIdentifierAsync(deliveryManDTO.Identifier);

            if (user != null)
                throw new InvalidOperationException(string.Format(BusinessMessage.Invalid_Operation_Warning, "entregador"));

            user = deliveryManDTO.Adapt<UserAuth>();

            user.Password = _passwordHasher.HashPassword(user, deliveryManDTO.Password);

            await _unitOfWork.Repository<UserAuth>().AddAsync(user);

            DeliveryMan deliveryMan = deliveryManDTO.Adapt<DeliveryMan>();

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
