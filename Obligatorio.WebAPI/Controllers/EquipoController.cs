using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEEquipo;

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
            return Ok(equipos);
        }
        catch (NoExisteEquipoException e)
        {
            return NotFound(e.Message);
        }
        catch (DatosInvalidosException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error inesperado al obtener los equipos.");
        }
    }
}