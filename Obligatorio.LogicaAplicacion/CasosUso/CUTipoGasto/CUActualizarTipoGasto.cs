using Obligatorio.DTOs.DTOs.DTOsPago;
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
    public class CUActualizarTipoGasto : ICUActualizarTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioAuditoria _repoAuditoria;

        public CUActualizarTipoGasto(IRepositorioTipoGasto repoTipoGasto, IRepositorioAuditoria repoAuditoria)
        {
            _repoTipoGasto = repoTipoGasto;
            _repoAuditoria = repoAuditoria;
        }

        public void ActualizarTipoGasto(DTOActualizarTipoGasto dto)
        {
            var buscado = _repoTipoGasto.FindById(dto.Id);
            if (buscado == null)
                throw new Exception("No se encontró el tipo de gasto.");

            buscado.Nombre = dto.Nombre;
            buscado.Descripcion = dto.Descripcion;

            _repoTipoGasto.Update(buscado);

            _repoAuditoria.Add(new Auditoria
            {
                Fecha = DateTime.Now,
                Accion = $"Actualización de tipo de gasto '{buscado.Nombre}'",
                Usuario = dto.UsuarioAdministrador
            });
        }
    }
}
