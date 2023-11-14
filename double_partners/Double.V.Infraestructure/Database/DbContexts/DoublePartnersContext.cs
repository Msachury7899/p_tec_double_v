using System;
using System.Collections.Generic;
using Double.V.Domain.Entities.SP_Results.Personas;
using Double.V.Infraestructure.Entities.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Double.V.Infraestructure.Database.DbContexts
{
    public partial class DoublePartnersContext : DbContext
    {
        public DoublePartnersContext()
        {
        }

        public DoublePartnersContext(DbContextOptions<DoublePartnersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonasGetAllResult> SP_PERSONAS_GET_ALL { get; set; }

        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<TiposIdentificacion> TiposIdentificacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.IdTipoIdentificacion).HasColumnName("id_tipo_identificacion");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.HasOne(d => d.IdTipoIdentificacionNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdTipoIdentificacion)
                    .HasConstraintName("FK_Personas_TiposIdentificacion");
            });

            modelBuilder.Entity<TiposIdentificacion>(entity =>
            {
                entity.ToTable("TiposIdentificacion");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.NombreTipo)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("nombre_tipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Password)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Login)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Personas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
