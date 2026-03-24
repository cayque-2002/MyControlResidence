using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Domain.Interfaces;
using MyControlResidence.Api.Infrastructure.Context;

namespace MyControlResidence.Api.Infrastructure.Repositorios
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _context;

        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pessoa pessoa)
        {
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pessoa>> GetAllAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa?> GetByIdAsync(long id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task UpdatePessoaAsync(long id, UpdatePessoaDto dto)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);

            if (pessoa == null)
                throw new Exception("Pessoa não encontrada");

            pessoa.Nome = dto.Nome;
            pessoa.Idade = dto.Idade;

            await _context.SaveChangesAsync();
            
        }

        public async Task DeletePessoaAsync(long id)
        {
            var pessoa = await _context.Pessoas
             .FirstOrDefaultAsync(p => p.Id == id);

            if (pessoa == null)
                throw new Exception("Pessoa não encontrada");

            var transacoesPessoa = await _context.Transacoes.Where(t => t.PessoaId == id).ToListAsync();

            if (transacoesPessoa.Any())
            {
                _context.Transacoes.RemoveRange(transacoesPessoa.ToArray());
            }

            _context.Pessoas.Remove(pessoa);

            await _context.SaveChangesAsync();
        }


    }
}
