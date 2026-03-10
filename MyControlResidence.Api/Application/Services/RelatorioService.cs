using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Domain.Enums;
using MyControlResidence.Api.Infrastructure.Context;

public class RelatorioService
{
    private readonly AppDbContext _context;

    public RelatorioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseRelatorioDto> GetRelatorioPorPessoa()
    {
        var result = await _context.Transacoes
            .Include(t => t.Pessoa)
            .GroupBy(t => t.Pessoa.Nome)
            .Select(g => new TransacoesResumoRelatorioDto
            {
                Chave = g.Key,

                Receita = g.Where(t => t.Tipo == TipoTransacao.Receita)
                           .Sum(t => t.Valor),

                Despesas = g.Where(t => t.Tipo == TipoTransacao.Despesa)
                            .Sum(t => t.Valor),

                Saldo = g.Where(t => t.Tipo == TipoTransacao.Receita).Sum(t => t.Valor)
                      - g.Where(t => t.Tipo == TipoTransacao.Despesa).Sum(t => t.Valor),

                Transacoes = g.Select(t => new TransacoesItensRelatorioDto
                {
                    Valor = t.Valor,
                    Tipo = t.Tipo,
                    DataHoraCriacao = t.DataHoraCriacao
                }).ToList()
            })
            .ToListAsync();

        var totalReceitas = result.Sum(r => r.Receita);
        var totalDespesas = result.Sum(r => r.Despesas);

        return new ResponseRelatorioDto
        {
            Itens = result,
            TotalReceitas = totalReceitas,
            TotalDespesas = totalDespesas,
            TotalSaldo = totalReceitas - totalDespesas
        };
    }

    public async Task<ResponseRelatorioDto> GetRelatorioPorCategoria()
    {
        var result = await _context.Transacoes
            .Include(t => t.Categoria)
            .GroupBy(t => t.Categoria.Descricao)
            .Select(g => new TransacoesResumoRelatorioDto
            {
                Chave = g.Key,

                Receita = g.Where(t => t.Tipo == TipoTransacao.Receita)
                           .Sum(t => t.Valor),

                Despesas = g.Where(t => t.Tipo == TipoTransacao.Despesa)
                            .Sum(t => t.Valor),

                Saldo = g.Where(t => t.Tipo == TipoTransacao.Receita).Sum(t => t.Valor)
                      - g.Where(t => t.Tipo == TipoTransacao.Despesa).Sum(t => t.Valor),

                Transacoes = g.Select(t => new TransacoesItensRelatorioDto
                {
                    Valor = t.Valor,
                    Tipo = t.Tipo,
                    DataHoraCriacao = t.DataHoraCriacao
                }).ToList()
            })
            .ToListAsync();

        var totalReceitas = result.Sum(r => r.Receita);
        var totalDespesas = result.Sum(r => r.Despesas);

        return new ResponseRelatorioDto
        {
            Itens = result,
            TotalReceitas = totalReceitas,
            TotalDespesas = totalDespesas,
            TotalSaldo = totalReceitas - totalDespesas
        };
    }
}