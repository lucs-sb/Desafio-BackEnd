using Mapster;
using Microsoft.AspNetCore.Identity;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<Administrator> _passwordHasher;
        private readonly ITokenService _tokenService;

        public AdministratorService(IUnitOfWork unitOfWork, IPasswordHasher<Administrator> passwordHasher, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task CreateAsync(AdministratorDTO administradorDTO)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                Administrator administrador = administradorDTO.Adapt<Administrator>();

                administrador.Password = _passwordHasher.HashPassword(administrador, administradorDTO.Password);

                await _unitOfWork.Repository<Administrator>().AddAsync(administrador);

                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();

                throw;
            }
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            Administrator administrador = await _unitOfWork.Repository<Administrator>().GetByIdentifierAsync(loginDTO.Identifier) ?? throw new Exception();

            if (_passwordHasher.VerifyHashedPassword(administrador, administrador.Password!, loginDTO.Password) is PasswordVerificationResult.Failed)
                throw new Exception();

            return await _tokenService.GenerateToken(administrador.Id.ToString()!);
        }
    }
}
