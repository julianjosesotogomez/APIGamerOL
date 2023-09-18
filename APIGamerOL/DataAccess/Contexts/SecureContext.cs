using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APIGamerOL.Domain.Entities.SecureEntities;

namespace APIGamerOL.DataAccess.Contexts
{
    public partial class SecureContext : DbContext
    {
        public SecureContext()
        {
        }

        public SecureContext(DbContextOptions<SecureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Contrasena).HasMaxLength(100);

                entity.Property(e => e.CorreoElectronico).HasMaxLength(100);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.NombreUsuario).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
