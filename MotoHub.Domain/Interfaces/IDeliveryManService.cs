using MotoHub.Domain.DTOs;

namespace MotoHub.Domain.Interfaces;

public interface IDeliveryManService
{
    Task CreateAsync(DeliveryManDTO deliveryManDTO);
    Task<DeliveryManDTO?> GetByIdentifierAsync(string identifier);
    Task UpdateAsync(DeliveryManDTO deliveryManDTO);
    Task DeleteByIdentifierAsync(string id);
}
