using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria
{
    public interface ICUObtenerPorTipoGasto 
    {
        IEnumerable<Auditoria> Ejecutar(int idTipoGasto);

    }
}
