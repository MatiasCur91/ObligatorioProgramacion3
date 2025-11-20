namespace Obligatorio.LogicaNegocio.CustomExceptions.CEEquipo;

public class NoExisteEquipoException : Exception
{
    public NoExisteEquipoException()
    {
    }

    public NoExisteEquipoException(string? message) : base(message)
    {
    }
}