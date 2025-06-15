using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Settings;

namespace MotoHub.Repository;

public class RentalRepository : IRentalRepository
{
    private readonly IMongoDatabase _database;

    public RentalRepository(IOptions<MotoHubDatabaseSettings> motoHubDatabaseSettings)
    {
        var mongoClient = new MongoClient(
             motoHubDatabaseSettings.Value.ConnectionString);

        _database = mongoClient.GetDatabase(
            motoHubDatabaseSettings.Value.DatabaseName);
    }

    public Task CreateAsync(Rental rental)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Rental?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Rental rental)
    {
        throw new NotImplementedException();
    }
}
