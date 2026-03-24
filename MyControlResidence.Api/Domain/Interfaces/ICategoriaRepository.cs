using MyControlResidence.Api.Domain.Entidades;

namespace MyControlResidence.Api.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task AddAsync(Categoria transacao);
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(long id);
    }
}
