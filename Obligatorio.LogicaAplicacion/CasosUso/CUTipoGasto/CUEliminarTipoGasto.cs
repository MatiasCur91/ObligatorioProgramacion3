using Obligatorio.DTOs.DTOs.DTOsTipoGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUTipoGasto
{
    public class CUEliminarTipoGasto : ICUEliminarTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioAuditoria _repoAuditoria;

        public CUEliminarTipoGasto(IRepositorioTipoGasto repoTipoGasto, IRepositorioAuditoria repoAuditoria)
        {
            _repoTipoGasto = repoTipoGasto;
            _repoAuditoria = repoAuditoria;
        }
        public void EliminarTipoGasto(DTOBajaTipoGasto dto)
        {

            
            if (_repoTipoGasto.EstaEnUso(dto.Id))
                throw new Exception("No se puede eliminar el tipo de gasto porque está en uso en uno o más pagos.");

            
            var tipo = _repoTipoGasto.FindById(dto.Id);
            if (tipo == null)
                throw new Exception("El tipo de gasto no existe.");

            
            _repoTipoGasto.Remove(dto.Id);


            _repoAuditoria.Add(new Auditoria
            {
                Fecha = DateTime.Now,
                Accion = $"Baja de tipo de gasto '{tipo.Nombre}'",
                Usuario = dto.UsuarioAdministrador,
                Entidad = "Tipo de gasto",
                IdEntidad = dto.Id
            });
        }
    }
}
