using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEAltaUsuario
{
    public class UsuarioYaExisteException : Exception
    {
        public UsuarioYaExisteException()
        {
        }

        public UsuarioYaExisteException(string? message) : base(message)
        {
        }
    }
}
