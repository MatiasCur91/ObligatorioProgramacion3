using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUTipoGasto
{
    public class CUObtenerEquiposPagosUnicosMayores : ICUObtenerEquiposPagosUnicosMayores
    {
        private IRepositorioEquipo _repoEquipo;

        public CUObtenerEquiposPagosUnicosMayores(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public List<Equipo> ObtenerEquiposConPagosUnicosMayores(double monto)
        {
            if (monto <= 0)
            {
                throw new DatosInvalidosException("El monto debe ser mayor que cero.");
            }
            var equipos = _repoEquipo.ObtenerEquiposConPagosUnicosMayores(monto);
            if (equipos == null || !equipos.Any())
            {
                throw new NoExisteEquipoException("No hay equipos con pago unico mayor a ese monto.");
            }

            return _repoEquipo.ObtenerEquiposConPagosUnicosMayores(monto);
        }
    }
}
