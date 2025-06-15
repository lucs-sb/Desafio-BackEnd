using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;

namespace MotoHub.Domain.Interfaces;

public interface IRentalService
{
    Task CreateAsync(RentalDTO rentalDTO);
    Task<Rental?> GetByIdAsync(int id);
    Task UpdateAsync(RentalDTO rentalDTO);
    Task DeleteAsync(int id);
}
