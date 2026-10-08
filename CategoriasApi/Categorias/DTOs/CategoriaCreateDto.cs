namespace CategoriasApi.Categorias.DTOs;

// Entrada: datos para crear una categoría (el id lo genera la base de datos)
public class CategoriaCreateDto
{
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
}