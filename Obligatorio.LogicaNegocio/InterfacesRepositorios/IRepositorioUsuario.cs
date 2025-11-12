using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;


namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {
       
        Usuario FindByEmail(string email);
        
       
    }
}