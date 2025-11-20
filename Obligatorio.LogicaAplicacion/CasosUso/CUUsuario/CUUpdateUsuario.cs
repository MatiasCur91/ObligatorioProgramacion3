using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUUpdateUsuario : ICUUpdateUsuario
    {
        private readonly IRepositorioUsuario _repoUsuario;
        public CUUpdateUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public void Ejecutar(LogicaNegocio.Entidades.Usuario usuario)
        {
            _repoUsuario.Update(usuario);
        }
    }
}
