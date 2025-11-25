using Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Obligatorio.LogicaAplicacion.CasosUso.CUAuditoria
{
    public class CUObtenerPorTipoGasto : ICUObtenerPorTipoGasto
    {
        private readonly IRepositorioAuditoria _repoAuditoria;
        public CUObtenerPorTipoGasto(IRepositorioAuditoria repoAuditoria)
        {
            _repoAuditoria = repoAuditoria;
        }

        public IEnumerable<Auditoria> Ejecutar(int idTipoGasto)
        {
            return _repoAuditoria.ObtenerPorTipoGasto(idTipoGasto);
        }
    }
}
