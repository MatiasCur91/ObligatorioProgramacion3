using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.CasosUso.CUPago;
using Obligatorio.LogicaAplicacion.CasosUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.WebApp.Filtros;

namespace Obligatorio.WebApp.Controllers
{
    [LogueadoAuthorize]
    public class PagoController : Controller
    {
        private IRepositorioPago _repoPago;
        private ICUAltaPago _cuAltaPago;
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioUsuario _repoUsuario;
        private ICUObtenerUsuariosConPagosMayores _cuObtenerUsuarios;
        private ICUObtenerListadoMensual _cuObtenerListadoMensual;

        public PagoController(ICUAltaPago cuAltaPago,
            IRepositorioPago repoPago,
            IRepositorioTipoGasto repoTipoGasto, ICUObtenerUsuariosConPagosMayores cuObtenerUsuarios, ICUObtenerListadoMensual cuObtenerListadoMensual, IRepositorioUsuario repoUsuario)
        {
            _cuAltaPago = cuAltaPago;
            _repoPago = repoPago;
            _repoTipoGasto = repoTipoGasto;
            _cuObtenerUsuarios = cuObtenerUsuarios;
            _cuObtenerListadoMensual = cuObtenerListadoMensual;
            _repoUsuario = repoUsuario;

        }

        [HttpGet]
        public IActionResult Create()
        {
            var dto = new DTOAltaPago();
            dto.TiposGastos = _repoTipoGasto.FindAll();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Create(DTOAltaPago dto)
        {
            try
            {
                string email = HttpContext.Session.GetString("LogueadoEmail"); 
                Usuario usuarioActual = _repoUsuario.FindByEmail(email);
                Pago nuevoPago = MapperPago.FromDTOAltaPagoToPago(dto);
                nuevoPago.Usuario = usuarioActual;
                _repoPago.Add(nuevoPago);

                ViewBag.msg = "Pago registrado correctamente";
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            dto.TiposGastos = _repoTipoGasto.FindAll();
            return View(dto);
        }
        [GerenteAuthorize]
        [HttpGet]
        public IActionResult BuscarUsuariosConPagosMayores()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarUsuariosConPagosMayores(double monto)
        {
            var usuarios = _cuObtenerUsuarios.Ejecutar(monto);
           
            return View("ResultadoUsuarios", usuarios);
        }


        [GerenteAuthorize]
        [HttpGet]
        public IActionResult ListadoMensual()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ListadoMensual(int mes, int anio)
        {
            var dtoPagos = _cuObtenerListadoMensual.Obtener(mes, anio);

            if (dtoPagos.Count == 0)
            {
                ViewBag.Msg = "No existen pagos para el mes seleccionado.";
            }

            return View(dtoPagos);
        }
    }
}