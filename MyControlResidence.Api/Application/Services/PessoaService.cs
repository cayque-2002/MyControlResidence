using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Domain.Interfaces;
using MyControlResidence.Api.Infrastructure.Context;
using MyControlResidence.Api.Infrastructure.Repositorios;

public class PessoaService
{
    private readonly IPessoaRepository _repository;

    public PessoaService(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Pessoa>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Pessoa> Create(CreatePessoaDto dto)
    {
        var pessoa = new Pessoa
        {
            Nome = dto.Nome,
            Idade = dto.Idade,
            DataHoraCriacao = DateTime.UtcNow
        };

        await  _repository.AddAsync(pessoa);

        return pessoa;
    }

    public async Task Update(long id, UpdatePessoaDto dto)
    {       
        await _repository.UpdatePessoaAsync(id, dto);
    }

    public async Task Delete(long id)
    {
        await _repository.DeletePessoaAsync(id);
    }
}