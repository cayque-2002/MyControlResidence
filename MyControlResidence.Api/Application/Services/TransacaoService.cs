using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Domain.Enums;
using MyControlResidence.Api.Infrastructure.Context;

public class TransacaoService
{
    private readonly AppDbContext _context;

    public TransacaoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transacao>> GetAll()
    {
        return await _context.Transacoes
             .Include(t => t.Pessoa)
             .Include(t => t.Categoria)
             .ToListAsync();
    }

    public async Task<Transacao> Create(CreateTransacaoDto dto)
    {
        var pessoa = await _context.Pessoas.FindAsync(dto.PessoaId);
        var categoria = await _context.Categorias.FindAsync(dto.CategoriaId);

        if (pessoa == null)
            throw new BadHttpRequestException("Pessoa não encontrada");

        if (categoria == null)
            throw new BadHttpRequestException("Categoria não encontrada");

        // REGRA 1: menor de idade não pode ter receita
        if (pessoa.Idade < 18 && dto.Tipo == TipoTransacao.Receita)
            throw new BadHttpRequestException("Menor de idade não pode possuir receitas");

        // REGRA 2: categoria precisa permitir o tipo da transação
        if (categoria.Finalidade != FinalidadeCategoria.Ambas &&
            (FinalidadeCategoria)dto.Tipo != categoria.Finalidade)
        {
            throw new BadHttpRequestException("Categoria não permite esse tipo de transação");
        }

        var transacao = new Transacao
        {
            Descricao = dto.Descricao,
            CategoriaId = dto.CategoriaId,
            Categoria = categoria,
            PessoaId = dto.PessoaId,
            Pessoa = pessoa,
            Tipo = dto.Tipo,
            Valor = dto.Valor,
            DataHoraCriacao = DateTime.UtcNow
        };

        _context.Transacoes.Add(transacao);
        await _context.SaveChangesAsync();

        return transacao;
    }
}