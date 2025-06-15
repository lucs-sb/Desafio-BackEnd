using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Settings;

namespace MotoHub.Repository;

public class MotorcycleRepository : IMotorcycleRepository
{
    private readonly IMongoDatabase _database;

    public MotorcycleRepository(IOptions<MotoHubDatabaseSettings> motoHubDatabaseSettings)
    {
        var mongoClient = new MongoClient(
             motoHubDatabaseSettings.Value.ConnectionString);

        _database = mongoClient.GetDatabase(
            motoHubDatabaseSettings.Value.DatabaseName);
    }

    public Task CreateAsync(Motorcycle motorcycle)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdentifierAsync(string identifier)
    {
        throw new NotImplementedException();
    }

    public Task<Motorcycle?> GetByIdentifierAsync(string identifier)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Motorcycle motorcycle)
    {
        throw new NotImplementedException();
    }
}
