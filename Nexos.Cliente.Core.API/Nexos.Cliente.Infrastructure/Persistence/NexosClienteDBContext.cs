using Microsoft.EntityFrameworkCore;
using Nexos.Cliente.Domain.Core.Models;

namespace Nexos.Cliente.Infrastructure.Persistence
{
    public partial class NexosClienteDBContext : DbContext
    {
        public NexosClienteDBContext()
        {
        }

        public NexosClienteDBContext(DbContextOptions<NexosClienteDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.Property(e => e.CiudadNacimiento)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
