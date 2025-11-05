using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.DTOs.DTOsTipoGasto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto
{
    public interface ICUListarTipoGasto
    {
        List<DTOTipoGasto> ObtenerTipoGasto();
        DTOTipoGasto ObtenerTipoGastoPorId(int id);
    }
    
}
