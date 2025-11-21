namespace Obligatorio.LogicaNegocio.CustomExceptions.CEAuditoria;

public class NoExisteAuditoriaException : Exception
{
    public NoExisteAuditoriaException()
    {
    }

    public NoExisteAuditoriaException(string? message) : base(message)
    {
    }
}