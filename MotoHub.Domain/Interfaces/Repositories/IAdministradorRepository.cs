using MotoHub.Domain.Entities;

namespace MotoHub.Domain.Interfaces.Repositories
{
    public interface IAdministradorRepository
    {
        Task CreateAsync(Administrador administrador);
        Task<Administrador?> GetByIdentifierAsync(string identifier);
        Task UpdateAsync(Administrador administrador);
        Task DeleteByIdentifierAsync(string identifier);
    }
}