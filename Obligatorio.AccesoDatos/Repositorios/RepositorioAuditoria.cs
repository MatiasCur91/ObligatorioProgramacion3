using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.AccesoDatos.Repositorios
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        private ApplicationDbContext _context;

        public RepositorioAuditoria(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Auditoria auditoria)
        {
            _context.Auditorias.Add(auditoria);
            _context.SaveChanges();
        }
        
        public IEnumerable<Auditoria> ObtenerPorTipoGasto(int idTipoGasto)
        {
            return _context.Auditorias
                .Where(a => a.Entidad == "TipoGasto" &&
                            a.IdEntidad == idTipoGasto)
                .OrderByDescending(a => a.Fecha)
                .ToList();
        }
    }
}
