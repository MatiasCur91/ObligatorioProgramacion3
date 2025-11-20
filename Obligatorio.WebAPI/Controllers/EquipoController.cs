using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;

namespace Obligatorio.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EquipoController : Controller
{
    private  ICUObtenerEquiposPagosUnicosMayores _cuEquipos;

    public EquipoController(ICUObtenerEquiposPagosUnicosMayores cuEquipos)
    {
        _cuEquipos = cuEquipos;
    }

    [HttpGet("{monto}")]
    public IActionResult GetEquiposConPagosUnicos(double monto)
    {
        if (monto <= 0)
            return BadRequest("El monto debe ser mayor que cero");

        try
        {
            var equipos = _cuEquipos.ObtenerEquiposConPagosUnicosMayores(monto);

            if (!equipos.Any())
                return NotFound("No se encontraron equipos con pagos únicos superiores a ese monto.");

            return Ok(equipos);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error inesperado al obtener los equipos.");
        }
    }
}