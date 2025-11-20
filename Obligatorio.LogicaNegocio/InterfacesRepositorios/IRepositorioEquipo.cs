using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios;

public interface IRepositorioEquipo
{
    public List<Equipo> ObtenerEquiposConPagosUnicosMayores(double monto);
}