using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Settings;

namespace MotoHub.Infrastructure.Repositories;

public class DeliveryManRepository : IDeliveryManRepository
{
    private readonly IMongoDatabase _database;

    public DeliveryManRepository(IOptions<MotoHubDatabaseSettings> motoHubDatabaseSettings)
    {
        var mongoClient = new MongoClient(
             motoHubDatabaseSettings.Value.ConnectionString);

        _database = mongoClient.GetDatabase(
            motoHubDatabaseSettings.Value.DatabaseName);
    }

    public Task CreateAsync(DeliveryMan deliveryMan)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdentifierAsync(string identifier)
    {
        throw new NotImplementedException();
    }

    public Task<DeliveryMan?> GetByIdentifierAsync(string identifier)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(DeliveryMan deliveryMan)
    {
        throw new NotImplementedException();
    }
}
