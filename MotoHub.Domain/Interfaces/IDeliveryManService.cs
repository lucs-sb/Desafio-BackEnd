using MotoHub.Domain.DTOs;

namespace MotoHub.Domain.Interfaces;

public interface IDeliveryManService
{
    Task CreateAsync(DeliveryManDTO deliveryManDTO);

    Task UpdateAsync(string identifier, string driverLicenseImage);
}
