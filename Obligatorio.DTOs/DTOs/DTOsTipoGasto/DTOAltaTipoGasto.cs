using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsTipoGasto
{
    public class DTOAltaTipoGasto
    {
        public string Nombre { get; set; }
        public string UsuarioAdministrador { get; set; } // para auditoría

        public string Descripcion { get; set; }
    }
}
