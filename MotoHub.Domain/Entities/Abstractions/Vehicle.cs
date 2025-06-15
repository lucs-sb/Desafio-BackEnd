using MongoDB.Bson.Serialization.Attributes;

namespace MotoHub.Domain.Entities.Abstractions;

public abstract class Vehicle
{
    [BsonId]
    public string? Id { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public string? LicensePlate { get; set; }
    public string? Identifier { get; set; }
}
