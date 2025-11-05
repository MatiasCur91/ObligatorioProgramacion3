using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.DTOs.DTOs.DTOsUsuario;

public class DTOUsuario
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Rol { get; set; }
}