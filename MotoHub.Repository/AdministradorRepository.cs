using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Settings;

namespace MotoHub.Repository;

public class AdministradorRepository : IAdministradorRepository
{
    private readonly IMongoDatabase _database;

    public AdministradorRepository(IOptions<MotoHubDatabaseSettings> motoHubDatabaseSettings)
    {
        var mongoClient = new MongoClient(
             motoHubDatabaseSettings.Value.ConnectionString);

        _database = mongoClient.GetDatabase(
            motoHubDatabaseSettings.Value.DatabaseName);
    }

    public async Task CreateAsync(Administrador administrador)
    {
        await _database.GetCollection<Administrador>(nameof(Administrador))
            .InsertOneAsync(administrador);
    }

    public Task DeleteByIdentifierAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Administrador?> GetByIdentifierAsync(string identifier)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Administrador administrador)
    {
        throw new NotImplementedException();
    }
}
