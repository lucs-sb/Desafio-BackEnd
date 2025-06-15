using MotoHub.Domain.DTOs;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories;

namespace MotoHub.Application.Services;

public class DeliveryManService : IDeliveryManService
{
    private readonly IDeliveryManRepository _deliveryManRepository;

    public DeliveryManService(IDeliveryManRepository deliveryManRepository)
    {
        _deliveryManRepository = deliveryManRepository;
    }

    public async Task CreateAsync(DeliveryManDTO deliveryManDTO)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdentifierAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<DeliveryManDTO?> GetByIdentifierAsync(string identifier)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(DeliveryManDTO deliveryManDTO)
    {
        throw new NotImplementedException();
    }
}
