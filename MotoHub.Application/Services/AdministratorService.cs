using Mapster;
using Microsoft.AspNetCore.Identity;
using MotoHub.Application.Resources;
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

        public async Task CreateAsync(AdministratorDTO administratorDTO)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                UserAuth? administrador = await _unitOfWork.Repository<UserAuth>().GetByIdentifierAsync(administratorDTO.Identifier);

                if (administrador != null)
                    throw new InvalidOperationException(string.Format(BusinessMessage.Invalid_Operation_Warning, "administrator"));

                administrador = administratorDTO.Adapt<UserAuth>();

                administrador.Password = _passwordHasher.HashPassword(administrador, administratorDTO.Password);

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
