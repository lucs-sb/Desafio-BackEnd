using Mapster;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories;

namespace MotoHub.Application.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;

        public AdministradorService(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public async Task CreateAsync(AdministradorDTO administradorDTO)
        {
            Administrador administrador = administradorDTO.Adapt<Administrador>();

            await _administradorRepository.CreateAsync(administrador);
        }
    }
}
