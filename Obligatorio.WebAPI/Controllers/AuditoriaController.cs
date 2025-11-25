using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuditoriasController : ControllerBase
{
    private readonly ICUObtenerPorTipoGasto _cUObtenerPorTipoGasto;

    public AuditoriasController(ICUObtenerPorTipoGasto cUObtenerPorTipoGasto)
    {
        _cUObtenerPorTipoGasto = cUObtenerPorTipoGasto;

    }

    [HttpGet("tipogasto/{idTipoGasto}")]
    public ActionResult<IEnumerable<Auditoria>> ObtenerAuditoriaDeTipoGasto(int idTipoGasto)
    {
        var auditorias = _cUObtenerPorTipoGasto.Ejecutar(idTipoGasto);

        if (!auditorias.Any())
        {
            return NotFound("No hay auditorías para este tipo de gasto.");
        }
            

        return Ok(auditorias);
    }
}