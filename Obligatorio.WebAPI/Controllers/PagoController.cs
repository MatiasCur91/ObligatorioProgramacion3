using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly ICUObtenerPagos _CUObtenerPagos;
        private readonly ICUAltaPago _CUAltaPago;

        public PagoController(ICUObtenerPagos cuObtenerPagos, ICUAltaPago cuAltaPago)
        {
            _CUObtenerPagos = cuObtenerPagos;
            _CUAltaPago = cuAltaPago;
        }

        [HttpGet]
        public IActionResult GetPagos()
        {
            try
            {
                var dto = _CUObtenerPagos.ObtenerPagos();
                return Ok(dto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPago(int id)
        {
            try
            {
                var p = _CUObtenerPagos.ObtenerPago(id);
                return Ok(p);
            }
            catch (PagoNoEncontradoException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult AltaPago([FromBody] DTOAltaPago dto)
        {
            try
            {

                var email = User.FindFirst(ClaimTypes.Email)?.Value;

                if (string.IsNullOrEmpty(email))
                    return Unauthorized("No se pudo obtener el email del token.");

                _CUAltaPago.AltaPago(dto, email);

                return StatusCode(201); 
            }
            catch (DatosInvalidosException e)
            {
                return BadRequest(e.Message);
            }
            catch (UsuarioNoEncontradoException)
            {
                return NotFound("Usuario no encontrado.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
