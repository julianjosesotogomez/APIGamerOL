using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APIGamerOL.Domain.Entities.CRUDEntities;

namespace APIGamerOL.DataAccess.Contexts
{
    public partial class CRUDContext : DbContext
    {
        public CRUDContext()
        {
        }

        public CRUDContext(DbContextOptions<CRUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificaciones> Calificaciones { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;
        public virtual DbSet<Videojuegos> Videojuegos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificaciones>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Puntuacion).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Videojuego)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.VideojuegoId)
                    .HasConstraintName("FK__Calificac__Video__2F10007B");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Contrasena).HasMaxLength(100);

                entity.Property(e => e.CorreoElectronico).HasMaxLength(100);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.NombreUsuario).HasMaxLength(100);
            });

            modelBuilder.Entity<Videojuegos>(entity =>
            {
                entity.Property(e => e.Compañia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Puntaje)
                    .HasColumnType("decimal(3, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
