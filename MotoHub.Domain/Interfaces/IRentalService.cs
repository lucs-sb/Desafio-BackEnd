using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;

namespace MotoHub.Domain.Interfaces;

public interface IRentalService
{
    Task CreateAsync(RentalDTO rentalDTO);
    Task<RentalResponseDTO> GetByIdAsync(string identifier);
    Task UpdateAsync(string identifier, DateTime returnDate);
}
