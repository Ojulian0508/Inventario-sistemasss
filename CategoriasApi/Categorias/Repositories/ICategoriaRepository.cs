using CategoriasApi.Categorias.Entities;

namespace CategoriasApi.Categorias.Repositories;

public interface ICategoriaRepository
{
    Task<List<Categoria>> ObtenerTodasAsync();
    Task<Categoria?> ObtenerPorIdAsync(int id);
    Task<Categoria> CrearAsync(Categoria categoria);
    Task ActualizarAsync(Categoria categoria);
    Task EliminarAsync(Categoria categoria);
}