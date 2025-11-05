using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Equipo)
                .WithMany(e => e.Usuarios)
                .HasForeignKey(u => u.EquipoId)
                .IsRequired(false);

            
            modelBuilder.Entity<Usuario>().OwnsOne(u => u.NombreCompleto, nombreCompleto =>
            {
                nombreCompleto.Property(n => n.Nombre).HasColumnName("Nombre");
                nombreCompleto.Property(n => n.Apellido).HasColumnName("Apellido");
            });

            
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.TipoGasto)
                .WithMany()
                .HasForeignKey(p => p.TipoGastoID)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Pago>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<PagoUnico>("PagoUnico")
                .HasValue<PagoRecurrente>("PagoRecurrente");
        }

       
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PagoRecurrente> PagosRecurrentes { get; set; }
        public DbSet<PagoUnico> PagosUnicos { get; set; }
        public DbSet<TipoGasto> TiposGastos { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
    }
}
