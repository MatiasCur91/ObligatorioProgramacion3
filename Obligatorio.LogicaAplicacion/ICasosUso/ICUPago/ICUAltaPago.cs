using Obligatorio.DTOs.DTOs.DTOsPago;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;

public interface ICUAltaPago
{
    void AltaPago(DTOAltaPago dto, string emailUsuario);
}