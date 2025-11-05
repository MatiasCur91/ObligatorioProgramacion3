using Obligatorio.DTOs.DTOs.DTOsPago;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;

public interface ICUObtenerPagos
{
    List<DTOPago> ObtenerPagos();
    DTOPago ObtenerPago(int id);
}