
using Obligatorio.DTOs.DTOs.DTOsUsuario;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;

public interface ICULogin
{
    DTOUsuario VerificarExistencia(DTOLogin dto);
}