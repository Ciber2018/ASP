namespace Logica
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Datos.Models;
    using System.Data.Entity.Infrastructure;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class LoteriaModel : DbContext
    {
        public LoteriaModel()
            : base("name=LotModel")
        {
        }

        public virtual DbSet<evento> evento { get; set; }
        public virtual DbSet<tarjeta> tarjeta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<evento>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<evento>()
                .Property(e => e.fecha)
                .IsUnicode(false);

            modelBuilder.Entity<evento>()
                .Property(e => e.hora)
                .IsUnicode(false);

            modelBuilder.Entity<evento>()
                .HasMany(e => e.tarjeta)
                .WithRequired(e => e.evento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tarjeta>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<tarjeta>()
                .Property(e => e.ID)
                .IsUnicode(false);
            
        }
    }
}
