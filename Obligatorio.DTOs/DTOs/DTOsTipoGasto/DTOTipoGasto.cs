using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsTipoGasto
{
    public class DTOTipoGasto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UsuarioAdministrador { get; set; } 

        public string Descripcion { get; set; }

      
    }
}
