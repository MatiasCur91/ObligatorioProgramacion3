using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsTipoGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.WebApp.Filtros;

namespace Obligatorio.WebApp.Controllers
{
    [AdministradorAuthorize]
    public class TipoGastoController : Controller
    {
        private ICUAltaTipoGasto _cuAltaTipoGasto;
        private ICUListarTipoGasto _cuListar;
        private ICUEliminarTipoGasto _cuEliminar;
        private ICUActualizarTipoGasto _cuActualizar;

        public TipoGastoController(
            ICUAltaTipoGasto cuAltaTipoGasto,
            ICUListarTipoGasto cuListar,
            ICUEliminarTipoGasto cuEliminar,
            ICUActualizarTipoGasto cuActualizar)
        {
            _cuAltaTipoGasto = cuAltaTipoGasto;
            _cuEliminar = cuEliminar;
            _cuListar = cuListar;
            _cuActualizar = cuActualizar;
        }

       
        public IActionResult Index()
        {
            var lista = _cuListar.ObtenerTipoGasto();
            return View(lista);
        }

 
        [HttpGet]
        public IActionResult Create()
        {
            return View(new DTOAltaTipoGasto());
        }

 
        [HttpPost]
        public IActionResult Create(DTOAltaTipoGasto dto)
        {
            try
            {
                
                dto.UsuarioAdministrador = "juaper@laEmpresa.com";
                _cuAltaTipoGasto.AltaTipoGasto(dto);

                TempData["Msg"] = "Tipo de gasto creado correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.msg = $"Error al crear el tipo de gasto: {ex.Message}";
                return View(dto);
            }
        }

       
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tg = _cuListar.ObtenerTipoGastoPorId(id);
            if (tg == null) return NotFound();

            var dto = new DTOActualizarTipoGasto
            {
                Id = tg.Id,
                Nombre = tg.Nombre,
                Descripcion = tg.Descripcion
            };

            return View(dto);
        }

       
        [HttpPost]
        public IActionResult Edit(DTOActualizarTipoGasto dto)
        {
            try
            {
                dto.UsuarioAdministrador = HttpContext.Session.GetString("LogueadoEmail");

                _cuActualizar.ActualizarTipoGasto(dto);

                TempData["Msg"] = "Tipo de gasto actualizado correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
               ViewBag.msg = $"Error al actualizar el tipo de gasto: {ex.Message}";
                return View(dto);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tg = _cuListar.ObtenerTipoGastoPorId(id);
            if (tg == null) return NotFound();
            return View(tg);
        }

       
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var dto = new DTOBajaTipoGasto
                {
                    Id = id,
                    UsuarioAdministrador = HttpContext.Session.GetString("LogueadoEmail")
                };

                _cuEliminar.EliminarTipoGasto(dto);
                TempData["Msg"] = "Tipo de gasto eliminado correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
