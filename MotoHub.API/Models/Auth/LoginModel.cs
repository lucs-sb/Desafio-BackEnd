using System.Text.Json.Serialization;

namespace MotoHub.API.Models.Auth;

public class LoginModel
{
    [JsonPropertyName("identificador")]
    public string? Identifier { get; set; }

    [JsonPropertyName("senha")]
    public string? Password { get; set; }
}
