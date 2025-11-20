using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEquipo
    {
        public List<Equipo> ObtenerEquiposConPagosUnicosMayores(double monto);
    }
}
