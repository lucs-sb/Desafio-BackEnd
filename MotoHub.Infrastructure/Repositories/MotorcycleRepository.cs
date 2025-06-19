using Microsoft.EntityFrameworkCore;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Repository;
using MotoHub.Infrastructure.Repositories.Base;

namespace MotoHub.Infrastructure.Repositories;

public class MotorcycleRepository : Repository<Motorcycle>, IMotorcycleRepository
{
    public MotorcycleRepository(AppDbContext context) : base(context) { }

    public async Task<List<Motorcycle>> GetAllOrByLicensePlateAsync(string licensePlate)
    {
        if (string.IsNullOrEmpty(licensePlate))
            return await _dbContext.Motorcycles.ToListAsync();

        return await _dbContext.Set<Motorcycle>()
                                    .Where(m => m.LicensePlate == licensePlate)
                                    .ToListAsync();
    }
}
