using Obligatorio.DTOs.DTOs.DTOsRol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsUsuario
{
    public class DTOAltaUsuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public List<DTORol> Roles { get; set; }

        public int IdRolSeleccionado { get; set; }

        public string Password { get; set; }

    }
}
