using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago
{
    public class CUObtenerPagosUsuario : ICUObtenerPagosUsuario
    {
        private IRepositorioPago _repoPago;

        public CUObtenerPagosUsuario(IRepositorioPago repoPago)
        {
            _repoPago = repoPago;

        }

        public List<DTOPago> Ejecutar(int id)
        {
            List<Pago> pagos = _repoPago.FindByUsuario(id);
            List<DTOPago> retorno = MapperPago.ToListDTOPago(pagos);
            if(retorno.Count == 0)
            {
                throw new PagoNoEncontradoException();
            }
            return retorno;
        }
    }
}
