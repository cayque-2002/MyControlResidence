using MyControlResidence.Api.Domain.Entidades;

namespace MyControlResidence.Api.Domain.Interfaces
{
    public interface IPessoaRepository
    {
        Task AddAsync(Pessoa transacao);
        Task<List<Pessoa>> GetAllAsync();
        Task UpdatePessoaAsync(long id, UpdatePessoaDto dto);
        Task DeletePessoaAsync(long id);
        Task<Pessoa?> GetByIdAsync(long id);
    }
}
