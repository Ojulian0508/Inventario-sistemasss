using CategoriasApi.Categorias.Data;
using CategoriasApi.Categorias.Entities;
using Microsoft.EntityFrameworkCore;

namespace CategoriasApi.Categorias.Repositories;

// Único lugar que habla con la base de datos
public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _db;

    public CategoriaRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Categoria>> ObtenerTodasAsync() =>
        await _db.Categorias.OrderBy(c => c.IdCategoria).ToListAsync();

    public async Task<Categoria?> ObtenerPorIdAsync(int id) =>
        await _db.Categorias.FindAsync(id);

    public async Task<Categoria> CrearAsync(Categoria categoria)
    {
        _db.Categorias.Add(categoria);
        await _db.SaveChangesAsync();
        return categoria;
    }

    public async Task ActualizarAsync(Categoria categoria)
    {
        _db.Categorias.Update(categoria);
        await _db.SaveChangesAsync();
    }

    public async Task EliminarAsync(Categoria categoria)
    {
        try
        {
            _db.Categorias.Remove(categoria);
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            // Llave foránea: hay equipos que usan esta categoría
            throw new InvalidOperationException(
                "No se puede eliminar: hay equipos asociados a esta categoría.");
        }
    }
}
