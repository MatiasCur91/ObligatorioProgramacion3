using Obligatorio.DTOs.DTOs.DTOsTipoGasto;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUTiposDePago
{
    public class CUAltaTipoGasto : ICUAltaTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioAuditoria _repoAuditoria;

        public CUAltaTipoGasto(IRepositorioTipoGasto repoTipoGasto, IRepositorioAuditoria repoAuditoria)
        {
            _repoTipoGasto = repoTipoGasto;
            _repoAuditoria = repoAuditoria;
        }

        public void AltaTipoGasto(DTOAltaTipoGasto dto)
        {
            // 1️. Crear la entidad desde el DTO
            TipoGasto nuevo = MapperTipoGasto.FromDtoAltaTipoGasto(dto);

            // 2️. Guardar en el repositorio
            _repoTipoGasto.Add(nuevo);

            // 3️. Registrar en la auditoría
            _repoAuditoria.Add(new Auditoria
            {
                Fecha = DateTime.Now,
                Accion = $"Alta de tipo de gasto '{nuevo.Nombre}'",
                Usuario = dto.UsuarioAdministrador // este dato viene desde el controlador (el admin logueado)
            });
        }
    }
}
