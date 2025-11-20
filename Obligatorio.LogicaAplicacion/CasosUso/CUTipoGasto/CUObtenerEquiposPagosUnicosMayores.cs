using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUTipoGasto;

public class CUObtenerEquiposPagosUnicosMayores : ICUObtenerEquiposPagosUnicosMayores
{
    private  IRepositorioEquipo _repoEquipo;

    public CUObtenerEquiposPagosUnicosMayores(IRepositorioEquipo repoEquipo)
    {
        _repoEquipo = repoEquipo;
    }

    public List<Equipo> ObtenerEquiposConPagosUnicosMayores(double monto)
    {
        if (monto <= 0)
            throw new ArgumentException("El monto debe ser mayor que cero.");

        return _repoEquipo.ObtenerEquiposConPagosUnicosMayores(monto);
    }
}