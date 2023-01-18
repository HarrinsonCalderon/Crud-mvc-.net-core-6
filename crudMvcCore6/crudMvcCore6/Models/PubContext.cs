using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace crudMvcCore6.Models
{
    public partial class PubContext : DbContext
    {
        public PubContext()
        {
        }

        public PubContext(DbContextOptions<PubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beer> Beers { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=TIU-1382\\MSSQLSERVER2;database=Pub;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>(entity =>
            {
                entity.HasKey(e => e.Beerld)
                    .HasName("PK__Beer__2933C80462C3671F");

                entity.ToTable("Beer");

                entity.Property(e => e.NameB)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkBrandldNavigation)
                    .WithMany(p => p.Beers)
                    .HasForeignKey(d => d.FkBrandld)
                    .HasConstraintName("fkbran");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Brandld)
                    .HasName("PK__Brand__DAD651BE595569AB");

                entity.ToTable("Brand");

                entity.Property(e => e.NameB)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
