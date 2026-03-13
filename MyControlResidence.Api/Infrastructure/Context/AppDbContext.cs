using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;

namespace MyControlResidence.Api.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Pessoa> Pessoas { get; set; }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Transacao> Transacoes { get; set; }
}