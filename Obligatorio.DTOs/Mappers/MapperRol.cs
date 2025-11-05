using Obligatorio.DTOs.DTOs.DTOsRol;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public static class MapperRol
    {
       

        public static DTORol FromRolToDtoRol(Rol r)
        {
            DTORol dto = new DTORol();
            dto.Nombre = r.Nombre;
            dto.Id = r.Id;

            return dto;
        }

        public static List<DTORol> ToListDTORol(List<Rol> listRoles)
        {
            List<DTORol> ret = new List<DTORol>();

            foreach (Rol r in listRoles) 
            {
                DTORol dtoRol = MapperRol.FromRolToDtoRol(r);
                ret.Add(dtoRol);
            }

            return ret;
        }
    }
}
