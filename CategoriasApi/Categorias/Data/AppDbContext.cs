using CategoriasApi.Categorias.Entities;
using Microsoft.EntityFrameworkCore;

namespace CategoriasApi.Categorias.Data;

// Configuración de Entity Framework: conecta las entidades con la base de datos
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Categoria> Categorias => Set<Categoria>();
}