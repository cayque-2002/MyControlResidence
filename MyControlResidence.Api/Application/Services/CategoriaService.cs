using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Infrastructure.Context;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Infrastructure.Repositorios;
using MyControlResidence.Api.Domain.Interfaces;

public class CategoriaService
{
    private readonly ICategoriaRepository _repository;

    public CategoriaService(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Categoria>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Categoria> Create(CreateCategoriaDto dto)
    {
        var categoria = new Categoria
        {
            Descricao = dto.Descricao,
            Finalidade = dto.Finalidade,
            DataHoraCriacao = DateTime.UtcNow
        };

        await _repository.AddAsync(categoria);

        return categoria;
    }
}