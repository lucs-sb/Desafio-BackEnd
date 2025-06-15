using MongoDB.Bson.Serialization.Attributes;

namespace MotoHub.Domain.Entities.Abstractions;

public abstract class User
{
    [BsonId]
    public string? Id { get; set; }
    public string? Password { get; set; }
    public string? Identifier { get; set; }
}