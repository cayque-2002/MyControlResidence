using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Context;
using MyControlResidence.Api.Entidades;
using MyControlResidence.Api.Enums;

namespace MyControlResidence.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransacaoController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransacaoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Transacao>>> GetAll()
    {
        return await _context.Transacoes
            .Include(t => t.PessoaId)
            .Include(t => t.CategoriaId)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Transacao transacao)
    {
        var pessoa = await _context.Pessoas.FindAsync(transacao.PessoaId);
        var categoria = await _context.Categorias.FindAsync(transacao.CategoriaId);

        if (pessoa == null)
            return BadRequest("Pessoa não encontrada");

        if (categoria == null)
            return BadRequest("Categoria não encontrada");

        // REGRA 1: menor de idade não pode ter receita
        if (pessoa.Idade < 18 && transacao.Tipo == TipoTransacao.Receita)
            return BadRequest("Menor de idade não pode possuir receitas");

        // REGRA 2: categoria precisa permitir o tipo da transação
        if (categoria.Finalidade != FinalidadeCategoria.Ambas &&
            (FinalidadeCategoria)transacao.Tipo != categoria.Finalidade)
        {
            return BadRequest("Categoria não permite esse tipo de transação");
        }

        _context.Transacoes.Add(transacao);
        await _context.SaveChangesAsync();

        return Ok(transacao);
    }
}