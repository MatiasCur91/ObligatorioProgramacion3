using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsTipoGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;

namespace Obligatorio.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipoGastoController : ControllerBase
{
    private readonly ICUListarTipoGasto _cuListarTipoGasto;

    public TipoGastoController(ICUListarTipoGasto cuListarTipoGasto)
    {
        _cuListarTipoGasto = cuListarTipoGasto;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var lista = _cuListarTipoGasto.ObtenerTipoGasto();

        var dto = lista.Select(tg => new DTOTipoGasto
        {
            Id = tg.Id,
            Nombre = tg.Nombre,
            Descripcion = tg.Descripcion
        }).ToList();

        return Ok(dto);
    }
}