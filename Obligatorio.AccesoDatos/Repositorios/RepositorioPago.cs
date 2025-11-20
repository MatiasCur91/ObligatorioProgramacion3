using Microsoft.EntityFrameworkCore;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.ValueObjects;

namespace Obligatorio.AccesoDatos.Repositorios;

public class RepositorioPago : IRepositorioPago
{

    private ApplicationDbContext _context;

    public RepositorioPago(ApplicationDbContext context)
    {
        _context = context;
    }


    public int Add(Pago nuevo)
    {
        _context.Pagos.Add(nuevo);
        _context.SaveChanges();
        return nuevo.Id;
    }

    public List<Pago> FindAll()
    {
        return _context.Pagos
            .Include(p => p.TipoGasto)
            .Include(p => p.Usuario)
            .ToList();
    }


    public Pago FindById(int id)
    {
        return _context.Pagos
            .Include(p => p.TipoGasto)
            .Include(p => p.Usuario)
            .FirstOrDefault(p => p.Id == id);
    }



    public List<Pago> FindByUsuario(int usuarioId)
    {
        return _context.Pagos
            .Include(p => p.TipoGasto)
            .Include(p => p.Usuario)              
            .Where(p => p.Usuario.Id == usuarioId)
            .ToList();
    }

    public void Remove(int id)
    {
        var pago = _context.Pagos.Find(id);
        if (pago != null)
        {
            _context.Pagos.Remove(pago);
            _context.SaveChanges();
        }
    }

    public void Update(Pago pago)
    {
        _context.Pagos.Update(pago);
        _context.SaveChanges();
    }



    public List<Usuario> ObtenerUsuariosConPagosMayores(double monto)
    {
        List<Usuario> usuarios = _context.Pagos
             .AsNoTracking() 
    .Include(p => p.Usuario)
    .GroupBy(p => p.Usuario)
    .Where(g => g.Sum(p => p.MontoTotal) > monto)
    .Select(g => new Usuario
    {
        Id = g.Key.Id,
     
        
    })
    .ToList();

        return usuarios;
    }

}