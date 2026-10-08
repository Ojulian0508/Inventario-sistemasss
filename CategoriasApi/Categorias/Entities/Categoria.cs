using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CategoriasApi.Categorias.Entities;

// Representa la tabla "categorias" de la base de datos
[Table("categorias")]
public class Categoria
{
    [Key]
    [Column("id_categoria")]
    public int IdCategoria { get; set; }

    [Column("nombre")]
    [Required, MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Column("descripcion")]
    [MaxLength(255)]
    public string? Descripcion { get; set; }
}