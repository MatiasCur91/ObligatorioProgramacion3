using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEPago
{
    public class UsuarioNoEncontradoException : Exception
    {
        public UsuarioNoEncontradoException()
        {
        }

        public UsuarioNoEncontradoException(string? message) : base(message)
        {
        }

    }
}
