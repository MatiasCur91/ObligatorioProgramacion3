namespace Obligatorio.LogicaNegocio.Entidades;

public class Equipo
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public List<Usuario> Usuarios {get; set;}
}