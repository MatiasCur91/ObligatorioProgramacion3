using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.ValueObjects
{
    public class NombreCompletoVO
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }

        public NombreCompletoVO()
        {

        }
        public NombreCompletoVO(string n, string a)
        {
            if (String.IsNullOrEmpty(n))
            {
                throw new DatosInvalidosException("El nombre es vacío");

            }
            if (String.IsNullOrEmpty(a))
            {
                throw new DatosInvalidosException("El apellido es vacío");

            }
            Nombre = n;
            Apellido = a;
        }
    }
}
