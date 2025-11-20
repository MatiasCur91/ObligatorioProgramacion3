using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        
        private ICUGenerarPasswordAleatoria _cUGenerarPasswordAleatoria;
        private ICUObtenerUsuarioPorEmail _cUObtenerUsuarioPorEmail;
        private ICUUpdateUsuario _cUUpdateUsuario;


        public UsuarioController(ICUGenerarPasswordAleatoria cUGenerarPasswordAleatoria, ICUObtenerUsuarioPorEmail cUObtenerUsuarioPorEmail, ICUUpdateUsuario cUUpdateUsuario)
        {
            _cUGenerarPasswordAleatoria = cUGenerarPasswordAleatoria;
            _cUObtenerUsuarioPorEmail = cUObtenerUsuarioPorEmail;
            _cUUpdateUsuario = cUUpdateUsuario;
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost("reset-password/{email}")]
        public IActionResult ResetPassword(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                   return BadRequest("Ingrese un email valido.");
                }

                Usuario usuario = _cUObtenerUsuarioPorEmail.Ejecutar(email);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }

                string nuevaPassword = _cUGenerarPasswordAleatoria.Generar();
                string hashPasword = Utilidades.Crypto.HashPasswordConBcrypt(nuevaPassword, 10);

                usuario.Password = hashPasword;

                _cUUpdateUsuario.Ejecutar(usuario);


                return Ok(new
                {
                    Mensaje = "Contraseña reseteada correctamente.",
                    NuevaPassword = nuevaPassword
                });
            }
            catch (DatosInvalidosException e)
            {
                
                return BadRequest(e.Message);
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

      

    }
}
