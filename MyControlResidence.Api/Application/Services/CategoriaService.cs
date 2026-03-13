using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Infrastructure.Context;
using MyControlResidence.Api.Domain.Entidades;

public class CategoriaService
{
    private readonly AppDbContext _context;

    public CategoriaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> GetAll()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<Categoria> Create(CreateCategoriaDto dto)
    {
        var categoria = new Categoria
        {
            Descricao = dto.Descricao,
            Finalidade = dto.Finalidade,
            DataHoraCriacao = DateTime.UtcNow
        };

        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return categoria;
    }
}