using CategoriasApi.Categorias.DTOs;
using CategoriasApi.Categorias.Services;
using Microsoft.AspNetCore.Mvc;

namespace CategoriasApi.Categorias.Controllers;

// Recibe la petición HTTP y devuelve la respuesta HTTP
[ApiController]
[Route("Categorias")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _service;

    public CategoriasController(ICategoriaService service)
    {
        _service = service;
    }

    // GET /categorias
    [HttpGet]
    public async Task<ActionResult<List<CategoriaDto>>> ObtenerTodas() =>
        Ok(await _service.ObtenerTodasAsync());

    // GET /categorias/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoriaDto>> ObtenerPorId(int id)
    {
        var categoria = await _service.ObtenerPorIdAsync(id);
        return categoria is null ? NotFound() : Ok(categoria);
    }

    // POST /categorias
    [HttpPost]
    public async Task<ActionResult<CategoriaDto>> Crear(CategoriaCreateDto dto)
    {
        try
        {
            var creada = await _service.CrearAsync(dto);
            return Created($"/categorias/{creada.IdCategoria}", creada);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // PUT /categorias/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar(int id, CategoriaUpdateDto dto)
    {
        try
        {
            var actualizada = await _service.ActualizarAsync(id, dto);
            return actualizada ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // DELETE /categorias/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        try
        {
            var eliminada = await _service.EliminarAsync(id);
            return eliminada ? NoContent() : NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { error = ex.Message });
        }
    }
}