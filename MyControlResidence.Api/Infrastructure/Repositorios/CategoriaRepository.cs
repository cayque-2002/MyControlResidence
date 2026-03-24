using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Domain.Interfaces;
using MyControlResidence.Api.Infrastructure.Context;

namespace MyControlResidence.Api.Infrastructure.Repositorios
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria?> GetByIdAsync(long id)
        {
            return await _context.Categorias.FindAsync(id);
        }
    }
}
