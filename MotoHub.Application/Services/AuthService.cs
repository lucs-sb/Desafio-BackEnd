using Microsoft.AspNetCore.Identity;
using MotoHub.Application.Resources;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<UserAuth> _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthService(IUnitOfWork unitOfWork, IPasswordHasher<UserAuth> passwordHasher, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
    {
        try
        {
            UserAuth user = await _unitOfWork.Repository<UserAuth>().GetByIdentifierAsync(loginDTO.Identifier) ?? throw new InvalidOperationException(string.Format(BusinessMessage.Unauthorized_Warning));

            if (_passwordHasher.VerifyHashedPassword(user, user.Password!, loginDTO.Password) is PasswordVerificationResult.Failed)
                throw new InvalidOperationException(string.Format(BusinessMessage.Unauthorized_Warning));

            return await _tokenService.GenerateToken(user.Id.ToString()!, user.IsAdmin);
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new UnauthorizedAccessException();
        }
    }
}
