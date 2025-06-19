using Mapster;
using Microsoft.AspNetCore.Identity;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<UserAuth> _passwordHasher;

        public AdministratorService(IUnitOfWork unitOfWork, IPasswordHasher<UserAuth> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateAsync(AdministratorDTO administradorDTO)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                UserAuth? administrador = await _unitOfWork.Repository<UserAuth>().GetByIdentifierAsync(administradorDTO.Identifier);

                if (administrador != null)
                    throw new Exception("Já existe um administrador com este identificador.");

                administrador = administradorDTO.Adapt<UserAuth>();

                administrador.Password = _passwordHasher.HashPassword(administrador, administradorDTO.Password);

                await _unitOfWork.Repository<UserAuth>().AddAsync(administrador);

                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();

                throw;
            }
        }
    }
}
