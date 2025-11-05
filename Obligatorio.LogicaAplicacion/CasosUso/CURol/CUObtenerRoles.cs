using Obligatorio.DTOs.DTOs.DTOsRol;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICURol;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CURol
{
    public class CUObtenerRoles : ICUObtenerRoles
    {
        private IRepositorioRol _repoRol;

        public CUObtenerRoles(IRepositorioRol repoRol)
        {
            _repoRol = repoRol;
        }

        public List<DTORol> ObtenerRoles()
        {

            //Mapear desde lista de rol a lista de DTOrol




            List<Rol> roles = _repoRol.FindAll();

            List<DTORol> retorno = MapperRol.ToListDTORol(roles);




            return retorno;
        }
    }
}
