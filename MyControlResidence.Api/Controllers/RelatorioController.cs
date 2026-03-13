using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Enums;
using MyControlResidence.Api.Infrastructure.Context;

namespace MyControlResidence.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RelatorioController : ControllerBase
{
    private readonly RelatorioService _service;

    public RelatorioController(RelatorioService relatorioService)
    {
        _service = relatorioService;
    }

    [HttpGet(nameof(GetRelatorioPorPessoa))]
    public async Task<IActionResult> GetRelatorioPorPessoa()
    {
        return Ok(await _service.GetRelatorioPorPessoa());

        //var transacoes = await _context.Transacoes
        //    .Include(t => t.Pessoa)
        //    .ToListAsync();

        //var result = transacoes
        //    .GroupBy(t => t.Pessoa.Nome)
        //    .Select(g => new
        //    {
        //        Pessoa = g.Key,
        //        Receita = g.Where(t => t.Tipo == TipoTransacao.Receita).Sum(t => t.Valor),
        //        Despesas = g.Where(t => t.Tipo == TipoTransacao.Despesa).Sum(t => t.Valor),
        //        Saldo = g.Where(t => t.Tipo == TipoTransacao.Receita).Sum(t => t.Valor)
        //                - g.Where(t => t.Tipo == TipoTransacao.Despesa).Sum(t => t.Valor)
        //    })
        //    .ToList();

        //var totalReceitas = result.Sum(r => r.Receita);
        //var totalDespesas = result.Sum(r => r.Despesas);

        //var relatorio = new
        //{
        //    Pessoa = result,
        //    totalReceitas = totalReceitas,
        //    totalDespesas = totalDespesas,
        //    totalSaldo = totalReceitas - totalDespesas
        //};

        //return Ok(relatorio);
    }

    [HttpGet(nameof(GetRelatorioPorCategoria))]
    public async Task<IActionResult> GetRelatorioPorCategoria()
    {
        return Ok(await _service.GetRelatorioPorCategoria());

        //var transacoes = await _context.Transacoes
        //    .Include(t => t.Categoria)
        //    .ToListAsync();

        //var result = transacoes
        //    .GroupBy(t => t.Categoria.Descricao)
        //    .Select(g => new
        //    {
        //        Categoria = g.Key,
        //        Receita = g.Where(t => t.Tipo == TipoTransacao.Receita).Sum(t => t.Valor),
        //        Despesas = g.Where(t => t.Tipo == TipoTransacao.Despesa).Sum(t => t.Valor),
        //        Saldo = g.Where(t => t.Tipo == TipoTransacao.Receita).Sum(t => t.Valor)
        //                - g.Where(t => t.Tipo == TipoTransacao.Despesa).Sum(t => t.Valor)
        //    })
        //    .ToList();

        //var totalReceitas = result.Sum(r => r.Receita);
        //var totalDespesas = result.Sum(r => r.Despesas);

        //var relatorio = new
        //{
        //    Categoria = result,
        //    totalReceitas = totalReceitas,
        //    totalDespesas = totalDespesas,
        //    totalSaldo = totalReceitas - totalDespesas
        //};

        //return Ok(relatorio);
    }
}