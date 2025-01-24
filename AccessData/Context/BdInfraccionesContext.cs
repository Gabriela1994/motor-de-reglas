using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Context
{
    public class BdInfraccionesContext : DbContext
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
        public virtual DbSet<EstadoInfraccion> EstadoInfraccions { get; set; } = null!;
        public virtual DbSet<Gravedad> Gravedads { get; set; } = null!;
        public virtual DbSet<Infraccion> Infraccions { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<TipoInfraccion> TipoInfraccions { get; set; } = null!;
        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camara>(entity =>
            {
                entity.ToTable("Camara");

                entity.Property(e => e.Coordenada)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coordenada");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.NumeroCamara).HasColumnName("numero_camara");

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

            modelBuilder.Entity<EstadoInfraccion>(entity =>
            {
                entity.ToTable("EstadoInfraccion");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Gravedad>(entity =>
            {
                entity.ToTable("Gravedad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Infraccion>(entity =>
            {
                entity.ToTable("Infraccion");

                entity.Property(e => e.Coordenada)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coordenada");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.MontoApagar).HasColumnName("montoAPagar");

                entity.HasOne(d => d.IdEstadoInfraccionNavigation)
                    .WithMany(p => p.Infraccions)
                    .HasForeignKey(d => d.IdEstadoInfraccion)
                    .HasConstraintName("FK_Infraccion_EstadoInfraccion");

                entity.HasOne(d => d.IdGravedadNavigation)
                    .WithMany(p => p.Infraccions)
                    .HasForeignKey(d => d.IdGravedad)
                    .HasConstraintName("FK_Infraccion_Gravedad");

                entity.HasOne(d => d.IdTipoInfraccionNavigation)
                    .WithMany(p => p.Infraccions)
                    .HasForeignKey(d => d.IdTipoInfraccion)
                    .HasConstraintName("FK_Infraccion_TipoInfraccion");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Infraccions)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("FK_Infraccion_Vehiculo");
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

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoInfraccion>(entity =>
            {
                entity.ToTable("TipoInfraccion");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.ToTable("TipoVehiculo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Usuario_Rol");
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

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Vehiculo_Marca");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK_Vehiculo_Modelo");

                entity.HasOne(d => d.IdTipoVehiculoNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdTipoVehiculo)
                    .HasConstraintName("FK_Vehiculo_TipoVehiculo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Vehiculo_Usuario");
            });
        }
    }
}
