using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Domain.Interfaces;
using MyControlResidence.Api.Infrastructure.Context;

namespace MyControlResidence.Api.Infrastructure.Repositorios
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly AppDbContext _context;

        public TransacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transacao transacao)
        {
            await _context.Transacoes.AddAsync(transacao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transacao>> GetAllAsync()
        {
            return await _context.Transacoes.ToListAsync();
        }

        public async Task<List<Transacao>> GetAllPessoaAsync()
        {
            return await _context.Transacoes
                .Include(t => t.Pessoa)
                .ToListAsync();
        }

        public async Task<List<Transacao>> GetAllCategoriaAsync()
        {
            return await _context.Transacoes
                .Include(t => t.Categoria)
                .ToListAsync();
        }

        public async Task<Transacao?> GetByIdAsync(long id)
        {
            return await _context.Transacoes.FindAsync(id);
        }
    }
}
