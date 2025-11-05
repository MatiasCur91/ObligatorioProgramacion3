using Microsoft.EntityFrameworkCore;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CEAltaUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioRol _repoRol;
        private IRepositorioUsuario _repoUsuario;



        public CUAltaUsuario(IRepositorioRol repoRol, IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
            _repoRol = repoRol;

        }
        public void AltaUsuario(DTOAltaUsuario dto)

        {

            try
            {

              
                Rol RolUsuario = _repoRol.FindById(dto.IdRolSeleccionado);

                Usuario nuevo = MapperUsuario.FromDtoAltaUsuarioToUsuario(dto);
                nuevo.Rol = RolUsuario;
                nuevo.Email = VerificarEmail(nuevo.Email);


                int h = _repoUsuario.Add(nuevo);

            }
            catch (UsuarioYaExisteException)
            {
                throw;
            }
        }

        public string VerificarEmail(string emailGenerado)
        {
            Random random = new Random();

            Usuario existente = _repoUsuario.FindByEmail(emailGenerado);

            if (existente != null)
            {
                int numero = random.Next(1000, 9999);
                emailGenerado = emailGenerado.Split('@')[0] + numero + "@laEmpresa.com";

            }

            return emailGenerado;
        }
    }
}
