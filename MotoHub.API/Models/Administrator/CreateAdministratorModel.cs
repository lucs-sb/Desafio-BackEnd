using System.Text.Json.Serialization;

namespace MotoHub.API.Models.Administrator;

public class CreateAdministratorModel
{
    [JsonPropertyName("identificador")]
    public string? Identifier { get; set; }

    [JsonPropertyName("senha")]
    public string? Password { get; set; }
}
