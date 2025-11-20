namespace Obligatorio.LogicaNegocio.CustomExceptions.CEAltaUsuario;

public class UsuarioNoEncontradoException : Exception
{
 
        public UsuarioNoEncontradoException()
        {
        }

        public UsuarioNoEncontradoException(string? message) : base(message)
        {
        }
    
}