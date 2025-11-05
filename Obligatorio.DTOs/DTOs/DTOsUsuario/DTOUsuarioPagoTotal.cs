using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsUsuario
{
    public class DTOUsuarioPagoTotal
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public double TotalPagado { get; set; }
    }
}
