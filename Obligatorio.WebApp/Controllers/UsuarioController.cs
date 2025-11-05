using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.CasosUso.CURol;
using Obligatorio.LogicaAplicacion.ICasosUso.ICURol;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.WebApp.Filtros;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private ICUObtenerRoles _CuObtenerRoles;
        private ICUAltaUsuario _CuAltaUsuario;
        private ICUObtenerUsuarios cUObtenerUsuarios;

        public UsuarioController(ICUObtenerRoles CuObtenerRoles,
          ICUAltaUsuario CualtaUsuario
          )
        {
            _CuObtenerRoles = CuObtenerRoles;
            _CuAltaUsuario = CualtaUsuario;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AdministradorYGerenteAuthorize]
        public IActionResult Create()
        {
            AltaUsuarioViewModel vm = new AltaUsuarioViewModel();

            foreach (var rol in _CuObtenerRoles.ObtenerRoles())
            {
                //agregar if para que no ponga el admin
                vm.Roles.Add(new SelectListItem { Text = rol.Nombre, Value = rol.Id.ToString() });

            }
            

            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(AltaUsuarioViewModel vm)
        {

            try
            {
                _CuAltaUsuario.AltaUsuario(vm.Dto);
                ViewBag.msg = "Alta correcta";
            }
            catch (Exception e)
            {

                ViewBag.msg = e.Message;
            }
            

            return View(vm);
        }

       

    }
}
