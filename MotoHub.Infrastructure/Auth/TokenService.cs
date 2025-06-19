using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MotoHub.Infrastructure.Auth;

public class TokenService : ITokenService
{
    private readonly IOptions<AuthSettings> _authSettings;

    public TokenService(IOptions<AuthSettings> authSettings) => _authSettings = authSettings;

    public Task<LoginResponseDTO> GenerateToken(string id, bool isAdmin)
    {
        List<Claim> claims =
        [
            new Claim(JwtRegisteredClaimNames.Sub, id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, id),
            new Claim(ClaimTypes.Role, isAdmin ? "Admin" : "DeliveryMan")
        ];

        DateTime expires = DateTime.UtcNow.AddMinutes(_authSettings.Value.AccessTokenExpirationMinutes);
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_authSettings.Value.SecretKey));
        JwtSecurityToken tokenData = new(
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
            claims: claims,
            expires: expires);

        string token = new JwtSecurityTokenHandler().WriteToken(tokenData);

        return Task.FromResult(new LoginResponseDTO(token, expires));
    }
}
