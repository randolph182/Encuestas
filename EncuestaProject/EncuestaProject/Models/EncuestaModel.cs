using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EncuestaProject.Models
{
    public partial class EncuestaModel : DbContext
    {
        public EncuestaModel()
            : base("name=EncuestaModel")
        {
        }

        public virtual DbSet<CAMPO> CAMPO { get; set; }
        public virtual DbSet<CUENTA> CUENTA { get; set; }
        public virtual DbSet<DET_ENC> DET_ENC { get; set; }
        public virtual DbSet<ENCUESTA> ENCUESTA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CAMPO>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<CAMPO>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<CAMPO>()
                .Property(e => e.tipo_campo)
                .IsUnicode(false);

            modelBuilder.Entity<CUENTA>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<CUENTA>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<CUENTA>()
                .HasMany(e => e.DET_ENC)
                .WithRequired(e => e.CUENTA)
                .HasForeignKey(e => e.id_usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ENCUESTA>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ENCUESTA>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ENCUESTA>()
                .HasMany(e => e.CAMPO)
                .WithRequired(e => e.ENCUESTA)
                .HasForeignKey(e => e.id_encuesta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ENCUESTA>()
                .HasMany(e => e.DET_ENC)
                .WithRequired(e => e.ENCUESTA)
                .HasForeignKey(e => e.id_encuesta)
                .WillCascadeOnDelete(false);
        }
    }
}
