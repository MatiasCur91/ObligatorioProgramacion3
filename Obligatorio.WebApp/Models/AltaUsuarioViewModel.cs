using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio.AccesoDatos.Repositorios;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;


namespace Obligatorio.WebApp.Models
{
    public class AltaUsuarioViewModel
    {
        private IRepositorioRol _repoRol;

        public AltaUsuarioViewModel()
        {
            
            Roles = new List<SelectListItem>(); 
        }

        public DTOAltaUsuario Dto { get; set; }

        public List<SelectListItem> Roles { get; set; }
    }

}
