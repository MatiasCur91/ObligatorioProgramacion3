namespace Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;

public class DatosInvalidosException : Exception
{
    public DatosInvalidosException()
    {
    }

    public DatosInvalidosException(string? message) : base(message)
    {
    }
}