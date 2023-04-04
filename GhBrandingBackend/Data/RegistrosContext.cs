using GhBrandingBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace GhBrandingBackend.Data

{
    public class RegistrosContext : DbContext
    {

        public RegistrosContext(DbContextOptions<RegistrosContext> options) : base(options)
        {
        }

        public DbSet<Registros> Registros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Registros>(e =>
            {
                e.ToTable("Registros");
                e.HasKey(p => p.Id);
                e.Property(p => p.Descricao).HasColumnType("varchar(200)").IsRequired();
                e.Property(p => p.RegistroInicial).HasColumnType("datetime").IsRequired();
                e.Property(p => p.RegistroFinal).HasColumnType("datetime").IsRequired();
                e.Property(p => p.HorasDia).HasColumnType("timespan");

            });
        }
    }
}
