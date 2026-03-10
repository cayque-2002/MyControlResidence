using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Infrastructure.Context;

public class PessoaService
{
    private readonly AppDbContext _context;

    public PessoaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pessoa>> GetAll()
    {
        return await _context.Pessoas.ToListAsync();
    }

    public async Task<Pessoa> Create(CreatePessoaDto dto)
    {
        var pessoa = new Pessoa
        {
            Nome = dto.Nome,
            Idade = dto.Idade,
            DataHoraCriacao = DateTime.UtcNow
        };

        _context.Pessoas.Add(pessoa);
        await _context.SaveChangesAsync();

        return pessoa;
    }

    public async Task Update(long id, UpdatePessoaDto dto)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);

        if (pessoa == null)
            throw new Exception("Pessoa não encontrada");

        pessoa.Nome = dto.Nome;
        pessoa.Idade = dto.Idade;

        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
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