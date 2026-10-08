using CategoriasApi.Categorias.DTOs;
using CategoriasApi.Categorias.Entities;
using CategoriasApi.Categorias.Repositories;

namespace CategoriasApi.Categorias.Services;

// Lógica de negocio: validaciones y conversión entre Entity y DTO
public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repo;

    public CategoriaService(ICategoriaRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<CategoriaDto>> ObtenerTodasAsync()
    {
        var categorias = await _repo.ObtenerTodasAsync();
        return categorias.Select(ADto).ToList();
    }

    public async Task<CategoriaDto?> ObtenerPorIdAsync(int id)
    {
        var categoria = await _repo.ObtenerPorIdAsync(id);
        return categoria is null ? null : ADto(categoria);
    }

    public async Task<CategoriaDto> CrearAsync(CategoriaCreateDto dto)
    {
        Validar(dto.Nombre, dto.Descripcion);

        var categoria = new Categoria
        {
            Nombre = dto.Nombre!.Trim(),
            Descripcion = LimpiarDescripcion(dto.Descripcion)
        };

        var creada = await _repo.CrearAsync(categoria);
        return ADto(creada);
    }

    public async Task<bool> ActualizarAsync(int id, CategoriaUpdateDto dto)
    {
        Validar(dto.Nombre, dto.Descripcion);

        var categoria = await _repo.ObtenerPorIdAsync(id);
        if (categoria is null) return false;

        categoria.Nombre = dto.Nombre!.Trim();
        categoria.Descripcion = LimpiarDescripcion(dto.Descripcion);
        await _repo.ActualizarAsync(categoria);
        return true;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var categoria = await _repo.ObtenerPorIdAsync(id);
        if (categoria is null) return false;

        await _repo.EliminarAsync(categoria);
        return true;
    }

    // ---------- Apoyo ----------
    private static void Validar(string? nombre, string? descripcion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre es obligatorio.");
        if (nombre.Trim().Length > 100)
            throw new ArgumentException("El nombre no puede superar 100 caracteres.");
        if (descripcion is not null && descripcion.Trim().Length > 255)
            throw new ArgumentException("La descripción no puede superar 255 caracteres.");
    }

    private static string? LimpiarDescripcion(string? descripcion) =>
        string.IsNullOrWhiteSpace(descripcion) ? null : descripcion.Trim();

    private static CategoriaDto ADto(Categoria c) => new()
    {
        IdCategoria = c.IdCategoria,
        Nombre = c.Nombre,
        Descripcion = c.Descripcion
    };
}