namespace MotoHub.Domain.DTOs.Response;

public record LoginResponseDTO (string access_token, DateTime expiration)
{
}
