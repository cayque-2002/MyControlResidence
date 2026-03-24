using MyControlResidence.Api.Domain.Entidades;

namespace MyControlResidence.Api.Domain.Interfaces
{
    public interface ITransacaoRepository
    {
        Task AddAsync(Transacao transacao);
        Task<List<Transacao>> GetAllAsync();
        Task<List<Transacao>> GetAllPessoaAsync();
        Task<List<Transacao>> GetAllCategoriaAsync();
        Task<Transacao?> GetByIdAsync(long id);
    }
}
