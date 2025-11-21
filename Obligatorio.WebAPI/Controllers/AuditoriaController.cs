using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuditoriasController : ControllerBase
{
    private readonly IRepositorioAuditoria _repoAuditoria;

    public AuditoriasController(IRepositorioAuditoria repoAuditoria)
    {
        _repoAuditoria = repoAuditoria;
    }

    [HttpGet("tipogasto/{idTipoGasto}")]
    public ActionResult<IEnumerable<Auditoria>> ObtenerAuditoriaDeTipoGasto(int idTipoGasto)
    {
        var auditorias = _repoAuditoria.ObtenerPorTipoGasto(idTipoGasto);

        if (!auditorias.Any())
        {
            return NotFound("No hay auditorías para este tipo de gasto.");
        }
            

        return Ok(auditorias);
    }
}