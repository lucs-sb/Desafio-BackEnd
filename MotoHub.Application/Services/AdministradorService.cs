using Mapster;
using Microsoft.AspNetCore.Identity;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories;

namespace MotoHub.Application.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;
        private readonly PasswordHasher<Administrador> _passwordHasher = new();
        private readonly ITokenService _tokenService;

        public AdministradorService(IAdministradorRepository administradorRepository, ITokenService tokenService)
        {
            _administradorRepository = administradorRepository;
            _tokenService = tokenService;
        }

        public async Task CreateAsync(AdministradorDTO administradorDTO)
        {
            Administrador administrador = administradorDTO.Adapt<Administrador>();

            administrador.Password = _passwordHasher.HashPassword(administrador, administradorDTO.Password);

            await _administradorRepository.CreateAsync(administrador);
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            Administrador administrador = await _administradorRepository.GetByIdentifierAsync(loginDTO.Identifier) ?? throw new Exception();

            if (_passwordHasher.VerifyHashedPassword(administrador, administrador.Password!, loginDTO.Password) is PasswordVerificationResult.Failed)
                throw new Exception();

            return await _tokenService.GenerateToken(administrador);
        }
    }
}
