using Obligatorio.DTOs.DTOs.DTOsPago;


namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;

public interface ICUObtenerListadoMensual
{
    List<DTOPago> Obtener(int mes, int anio);

}