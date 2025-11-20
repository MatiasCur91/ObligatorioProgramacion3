using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.AccesoDatos.Repositorios
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private ApplicationDbContext _context;

        public RepositorioEquipo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Equipo> ObtenerEquiposConPagosUnicosMayores(double monto)
        {
            return _context.Equipos
                .Where(eq =>
                    eq.Usuarios.Any(u =>
                        _context.Pagos.Any(p =>
                            p.Usuario.Id == u.Id &&
                            p is PagoUnico &&
                            p.MontoTotal > monto
                        )
                    )
                )
                .OrderByDescending(eq => eq.Nombre)
                .ToList();
        }
    }
}
