using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.AccesoDatos.Repositorios
{
    public class RepositorioRol : IRepositorioRol
    {

        private ApplicationDbContext _context;

        public RepositorioRol(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Rol nuevo)
        {

            _context.Roles.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;

        }
        public List<Rol> FindAll()
        {
            return _context.Roles.ToList();

        }

        

        public Rol FindById(int id)
        {
            return _context.Roles.Where(x => x.Id == id).SingleOrDefault();

        }

        public Rol FindRolByNombre(string texto)
        {
            return _context.Roles.Where(x => x.Nombre.ToLower() == texto.ToLower()).FirstOrDefault();
            
        }

        public void Remove(int id)
        {
            Rol Aliminar = FindById(id);
            if (Aliminar != null)
            {
                _context.Roles.Remove(Aliminar);
                _context.SaveChanges();
            }
        }

        public void Update(Rol obj)
        {
            _context.Roles.Update(obj);
            _context.SaveChanges();
        }
    }
}
