using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEEquipo
{
    public class NoExisteEquipoException : Exception
    {
        public NoExisteEquipoException()
        {
        }

        public NoExisteEquipoException(string? message) : base(message)
        {
        }
    }
}
