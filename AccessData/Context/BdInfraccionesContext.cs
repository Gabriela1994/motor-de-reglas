using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccess.Models;

namespace DataAccess.Context
{
    public partial class BdInfraccionesContext : DbContext
    {
        public BdInfraccionesContext()
        {
        }

        public BdInfraccionesContext(DbContextOptions<BdInfraccionesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Camara> Camaras { get; set; } = null!;
        public virtual DbSet<EstadoCamara> EstadoCamaras { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camara>(entity =>
            {
                entity.ToTable("Camara");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("longitud");

                entity.Property(e => e.NumeroCamara).HasColumnName("numeroCamara");

                entity.HasOne(d => d.IdEstadoCamaraNavigation)
                    .WithMany(p => p.Camaras)
                    .HasForeignKey(d => d.IdEstadoCamara)
                    .HasConstraintName("FK_Camara_EstadoCamara");
            });

            modelBuilder.Entity<EstadoCamara>(entity =>
            {
                entity.ToTable("EstadoCamara");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marca");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("Modelo");

                entity.Property(e => e.Año).HasColumnName("año");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Modelo_Marca");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.ToTable("TipoVehiculo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("Vehiculo");

                entity.Property(e => e.Chasis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("chasis");

                entity.Property(e => e.Patente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patente");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK_Vehiculo_Modelo");

                entity.HasOne(d => d.IdTipoVehiculoNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdTipoVehiculo)
                    .HasConstraintName("FK_Vehiculo_TipoVehiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
