using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Evidencia.Modelo
{
    public partial class evidenciaContext : DbContext
    {
        public virtual DbSet<Empleados> Empleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost; userid=root; Database=evidencia");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.ToTable("empleados");

                entity.Property(e => e.Cedula).HasColumnName("cedula");

                entity.Property(e => e.DiasVacaciones)
                    .HasColumnName("diasVacaciones")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.Salario)
                    .HasColumnName("salario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VacacionesPagar).HasColumnType("int(11)");
            });
        }
    }
}
