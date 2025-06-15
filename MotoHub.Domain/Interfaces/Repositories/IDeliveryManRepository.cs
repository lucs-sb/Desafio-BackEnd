using MotoHub.Domain.Entities;

namespace MotoHub.Domain.Interfaces.Repositories;

public interface IDeliveryManRepository
{
    Task CreateAsync(DeliveryMan deliveryMan);
    Task<DeliveryMan?> GetByIdentifierAsync(string identifier);
    Task UpdateAsync(DeliveryMan deliveryMan);
    Task DeleteByIdentifierAsync(string identifier);
}
