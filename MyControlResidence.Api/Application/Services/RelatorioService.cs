using MyControlResidence.Api.Domain.Enums;
using MyControlResidence.Api.Domain.Interfaces;

public class RelatorioService
{
    private readonly ITransacaoRepository _transacaoRepository;

    public RelatorioService(ITransacaoRepository transacaoRepository)
    {
        _transacaoRepository = transacaoRepository;
    }

    public async Task<ResponseRelatorioDto> GetRelatorioPorPessoa()
    {
        var transacoes = await _transacaoRepository.GetAllPessoaAsync();

        var result = transacoes
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
            .ToList();

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
        var transacoes = await _transacaoRepository.GetAllCategoriaAsync();

        var result = transacoes
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
            .ToList();

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