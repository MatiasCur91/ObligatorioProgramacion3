
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;


namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario;

public class CULogin : ICULogin

{
    IRepositorioUsuario _repoUsuario;
    public CULogin(IRepositorioUsuario repoUsuario)
    {
        _repoUsuario = repoUsuario;
    }
    public DTOUsuario VerificarExistencia(DTOLogin dto)
    {
        Usuario buscado = _repoUsuario.FindByEmail(dto.Email);
        if (buscado != null) {

            
            if (Utilidades.Crypto.VerificarPasswordConBcrypt(dto.Password,buscado.Password))
            {
                
                return MapperUsuario.FromUsuarioToDtoUsuario(buscado);
            }
        }
        throw new DatosInvalidosException();
    }
}




