using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.AccesoDatos.Repositorios
{
    public class RepositorioTipoGasto : IRepositorioTipoGasto
    {
       
            private ApplicationDbContext _context;

            public RepositorioTipoGasto(ApplicationDbContext context)
            {
                _context = context;
            }

            public int Add(TipoGasto tipoGasto)
            {
                _context.TiposGastos.Add(tipoGasto);
            _context.SaveChanges();
            return tipoGasto.Id;
        }

        public void Update(TipoGasto tipoGasto)
            {
                _context.TiposGastos.Update(tipoGasto);
                _context.SaveChanges();
            }

            public void Remove(int id)
            {
                var tipo = _context.TiposGastos.Find(id);
                if (tipo != null)
                {
                    _context.TiposGastos.Remove(tipo);
                    _context.SaveChanges();
                }
            }

            public TipoGasto? FindById(int id)
            {
                return _context.TiposGastos.FirstOrDefault(t => t.Id == id);
            }

            public List<TipoGasto> FindAll()
            {
                return _context.TiposGastos.ToList();
            }

            public bool EstaEnUso(int id)
            {
                              
                return _context.Pagos.Any(p => p.TipoGastoID == id);
            }
        
    }
}
