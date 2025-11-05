using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.DTOs.DTOsTipoGasto;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUTipoGasto
{
    public class CUListarTipoGasto : ICUListarTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;

        public CUListarTipoGasto(IRepositorioTipoGasto repoTipoGasto)
        {
            _repoTipoGasto = repoTipoGasto;
        }

        public List<DTOTipoGasto> ObtenerTipoGasto()
        {

            List<TipoGasto> tipoGastos = _repoTipoGasto.FindAll();
            List<DTOTipoGasto> retorno = MapperTipoGasto.ToListDTOTipoGasto(tipoGastos);

            return retorno;
        }

        public DTOTipoGasto ObtenerTipoGastoPorId(int id)
        {
            TipoGasto buscado = _repoTipoGasto.FindById(id);

            if (buscado is null)
            {

                //throw new TipoGastoNoEncontradoException();
                throw new Exception("No existe el tipo de gasto");

            }

            DTOTipoGasto retorno = MapperTipoGasto.FromTipoGastoToDtoTipoGasto(buscado);
            return retorno;
        }
    }
}
