using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.DTOs.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago
{
    public class CUObtenerUsuariosConPagosMayores : ICUObtenerUsuariosConPagosMayores
    {
        private IRepositorioPago _repoPago;
        private IRepositorioUsuario _repoUsuario;

        public CUObtenerUsuariosConPagosMayores(IRepositorioPago repoPago, IRepositorioUsuario repoUsuario)
        {
            _repoPago = repoPago;
            _repoUsuario = repoUsuario;
        }

        public List<DTOUsuario> Ejecutar(double monto)
        {
            List<Usuario> usuarios = _repoPago.ObtenerUsuariosConPagosMayores(monto);
            List<DTOUsuario> usuariosDtos = new List<DTOUsuario>();

            foreach (Usuario u in usuarios)
            {
                Usuario us = _repoUsuario.FindById(u.Id);
                usuariosDtos.Add(MapperUsuario.FromUsuarioToDtoUsuario(us));
            }
            return usuariosDtos;
        }
    }
}
