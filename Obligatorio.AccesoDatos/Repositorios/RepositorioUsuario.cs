using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.AccesoDatos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    private ApplicationDbContext _context;

    public RepositorioUsuario(ApplicationDbContext context)
    {
        _context = context;
    }


    public int Add(Usuario nuevo)
    {
        try
        {
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<Usuario> FindAll()
    {
        return _context.Usuarios.ToList();
    }
   
    public Usuario FindByEmail(string email)
    {
        return _context.Usuarios.Include(u => u.Rol).SingleOrDefault(u => u.Email == email);
    }
    public Usuario FindById(int id)
    {
        return _context.Usuarios.Include(u => u.Rol).SingleOrDefault(u => u.Id == id);
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        _context.SaveChanges();
    
    }


}