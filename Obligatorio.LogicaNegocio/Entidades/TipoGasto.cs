using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class TipoGasto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

       

        public void Validar()
        {
            //opcional validar si no existe  otro gasto con el mismo nombre
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new Exception("El nombre del tipo de gasto no puede estar vacío.");

        }
    }
}
