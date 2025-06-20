using Microsoft.EntityFrameworkCore;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Repository;
using MotoHub.Infrastructure.Repositories.Base;

namespace MotoHub.Infrastructure.Repositories;

public class RentalRepository : Repository<Rental>, IRentalRepository
{
    public RentalRepository(AppDbContext dbContext) : base(dbContext) {}

    public async Task<Rental?> GetByMotorcycleIdentifierAsync(string motorcycleIdentifier)
    {
        return await _dbContext.Rentals
        .Where(r => r.MotorcycleIdentifier == motorcycleIdentifier)
        .OrderByDescending(r => r.ReturnDate)
        .FirstOrDefaultAsync();
    }
}
