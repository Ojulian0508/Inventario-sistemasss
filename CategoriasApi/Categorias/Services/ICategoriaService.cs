using CategoriasApi.Categorias.DTOs;

namespace CategoriasApi.Categorias.Services;

public interface ICategoriaService
{
    Task<List<CategoriaDto>> ObtenerTodasAsync();
    Task<CategoriaDto?> ObtenerPorIdAsync(int id);
    Task<CategoriaDto> CrearAsync(CategoriaCreateDto dto);
    Task<bool> ActualizarAsync(int id, CategoriaUpdateDto dto);
    Task<bool> EliminarAsync(int id);
}