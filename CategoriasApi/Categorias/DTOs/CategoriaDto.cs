namespace CategoriasApi.Categorias.DTOs;

// Salida: lo que la API devuelve al cliente
public class CategoriaDto
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
}