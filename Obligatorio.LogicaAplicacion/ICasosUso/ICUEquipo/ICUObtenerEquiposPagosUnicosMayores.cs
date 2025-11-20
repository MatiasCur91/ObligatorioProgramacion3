using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;

public interface ICUObtenerEquiposPagosUnicosMayores
{
    List<Equipo> ObtenerEquiposConPagosUnicosMayores(double monto);

}