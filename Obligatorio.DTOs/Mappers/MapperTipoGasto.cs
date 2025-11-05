using Obligatorio.DTOs.DTOs.DTOsTipoGasto;
using Obligatorio.LogicaNegocio.Entidades;
using System.Collections.Generic;

namespace Obligatorio.DTOs.Mappers
{
    public static class MapperTipoGasto
    {
        public static TipoGasto FromDtoAltaTipoGasto(DTOAltaTipoGasto dto)
        {
            return new TipoGasto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                
            };
        }

        public static TipoGasto FromDtoActualizarTipoGasto(DTOActualizarTipoGasto dto)
        {
            return new TipoGasto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion

            };
        }

        public static TipoGasto FromDtoBajaTipoGasto(DTOBajaTipoGasto dto)
        {
            return new TipoGasto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
               
            };
        }


        public static DTOTipoGasto FromTipoGastoToDtoTipoGasto(TipoGasto tg)
        {
            return new DTOTipoGasto
            {
                Id = tg.Id,
                Nombre = tg.Nombre,
                Descripcion = tg.Descripcion
                
            };
        }

        public static List<DTOTipoGasto> ToListDTOTipoGasto(List<TipoGasto> listTipoGasto)
        {
            var ret = new List<DTOTipoGasto>();

            foreach (var tg in listTipoGasto)
            {
                ret.Add(FromTipoGastoToDtoTipoGasto(tg));
            }

            return ret;
        }
    }
}
