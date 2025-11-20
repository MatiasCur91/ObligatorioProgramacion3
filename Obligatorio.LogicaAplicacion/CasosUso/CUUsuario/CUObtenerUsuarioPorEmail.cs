using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUObtenerUsuarioPorEmail : ICUObtenerUsuarioPorEmail
    {
        private readonly IRepositorioUsuario _repoUsuario;
        public CUObtenerUsuarioPorEmail(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public Usuario Ejecutar(string email)
        {
            var usuario = _repoUsuario.FindByEmail(email);

            if (usuario == null)
            {
                throw new DatosInvalidosException("Usuario no encontrado.");
            }

            return usuario;
        }
    }
}
