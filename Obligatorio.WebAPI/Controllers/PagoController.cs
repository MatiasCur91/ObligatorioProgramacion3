using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System.Security.Claims;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private ICUObtenerPagos _CUObtenerPagos;
        private ICUAltaPago _CUAltaPago;
        private ICUObtenerPagosUsuario _cuObtenerPagosUsuario;
        private ICUObtenerUsuarioPorEmail _cUObtenerUsuarioPorEmail;

        public PagoController(ICUObtenerPagos cuObtenerPagos, ICUAltaPago cuAltaPago, ICUObtenerPagosUsuario cuObtenerPagosUsuario, ICUObtenerUsuarioPorEmail cUObtenerUsuarioPorEmail)
        {
            _CUObtenerPagos = cuObtenerPagos;
            _CUAltaPago = cuAltaPago;
            _cuObtenerPagosUsuario = cuObtenerPagosUsuario;
            _cUObtenerUsuarioPorEmail = cUObtenerUsuarioPorEmail;
        }
        [HttpGet]
        public IActionResult GetPagos()
        {

            try
            {
                List<DTOPago> dto = _CUObtenerPagos.ObtenerPagos();
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
                DTOPago p = _CUObtenerPagos.ObtenerPago(id);
                return Ok(p);
            }
            catch (PagoNoEncontradoException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

        [Authorize(Roles = "Empleado,Gerente")]
        [HttpGet("usuario-pagos/{email}")]
        public IActionResult ObtenerPagosUsuario(string email)
        {
            try
            {
                //caso de uso obtener usuario por mail
                var usuario = _cUObtenerUsuarioPorEmail.Ejecutar(email);

                var pagos = _cuObtenerPagosUsuario.Ejecutar(usuario.Id);

                return Ok(pagos);


            }
            catch (PagoNoEncontradoException e)
            {
                return StatusCode(404, e.Message);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }


        }

        [Authorize(Roles = "Empleado,Gerente, Administrador")]
        [HttpPost]

        public IActionResult AltaPago([FromBody] DTOAltaPago dto)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;

                if (string.IsNullOrEmpty(email))
                    return Unauthorized("El token no contiene email.");

                _CUAltaPago.AltaPago(dto, email);

                return StatusCode(201);
            }
            catch (DatosInvalidosException e)
            {
                return BadRequest(e.Message);
            }
            catch (UsuarioNoEncontradoException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
