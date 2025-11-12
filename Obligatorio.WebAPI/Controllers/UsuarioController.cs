using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private IRepositorioUsuario _repoUsuario;
        private ICUGenerarPasswordAleatoria _cUGenerarPasswordAleatoria;
        


        public UsuarioController(IRepositorioUsuario repoUsuario, ICUGenerarPasswordAleatoria cUGenerarPasswordAleatoria)
        {
            
            _repoUsuario = repoUsuario;
            _cUGenerarPasswordAleatoria = cUGenerarPasswordAleatoria;
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost("reset-password/{id}")]
        public IActionResult ResetPassword(int id)
        {
            try
            {
                Usuario usuario = _repoUsuario.FindById(id);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }

                string nuevaPassword = _cUGenerarPasswordAleatoria.Generar();
                string hashPasword = Utilidades.Crypto.HashPasswordConBcrypt(nuevaPassword, 10);
                
                usuario.Password = hashPasword;
                _repoUsuario.Update(usuario);

                return Ok(new
                {
                    Mensaje = "Contraseña reseteada correctamente.",
                    NuevaPassword = nuevaPassword
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

      

    }
}
