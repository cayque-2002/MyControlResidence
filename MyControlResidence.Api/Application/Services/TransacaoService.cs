using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Domain.Enums;
using MyControlResidence.Api.Domain.Interfaces;
using MyControlResidence.Api.Infrastructure.Context;
using MyControlResidence.Api.Infrastructure.Repositorios;


public class TransacaoService
{
    private readonly ITransacaoRepository _repository;
    private readonly IPessoaRepository _pessoaRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public TransacaoService(ITransacaoRepository repository, IPessoaRepository pessoaRepository,
        ICategoriaRepository categoriaRepository)
    {
        _pessoaRepository = pessoaRepository;
        _categoriaRepository = categoriaRepository; 
        _repository = repository;
    }
        
    public async Task<List<Transacao>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task Criar(CreateTransacaoDto dto)
    {
        var pessoa = await _pessoaRepository.GetByIdAsync(dto.PessoaId);

        if (pessoa == null)
            throw new Exception("Pessoa não encontrada");

        if (pessoa.Idade < 18 && dto.Tipo == TipoTransacao.Receita)
            throw new Exception("Menor de idade só pode ter despesas");

        var categoria = await _categoriaRepository.GetByIdAsync(dto.CategoriaId);

        if (categoria == null)
            throw new Exception("Categoria não encontrada");

        ValidarCategoriaComTipo(dto.Tipo, categoria.Finalidade);

        var transacao = new Transacao(dto.Descricao, dto.Valor, dto.Tipo, dto.PessoaId, dto.CategoriaId);

        await _repository.AddAsync(transacao);
    }

    private void ValidarCategoriaComTipo(TipoTransacao tipo, FinalidadeCategoria finalidade)
    {
        // REGRA: categoria com finalidade "ambas" aceita qualquer tipo
        if (finalidade == FinalidadeCategoria.Ambas)
            return;

        // REGRA: despesa só pode usar categoria de despesa
        if (tipo == TipoTransacao.Despesa && finalidade != FinalidadeCategoria.Despesa)
            throw new Exception("Categoria inválida para despesa");

        // REGRA: receita só pode usar categoria de receita
        if (tipo == TipoTransacao.Receita && finalidade != FinalidadeCategoria.Receita)
            throw new Exception("Categoria inválida para receita");
    }

}