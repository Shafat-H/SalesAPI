using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SalesAPI.Models.Write;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalesAPI.DbContexts
{
    public partial class WriteDbContext : DbContext
    {
        public WriteDbContext()
        {
        }

        public WriteDbContext(DbContextOptions<WriteDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SalesHeader> SalesHeader { get; set; }
        public virtual DbSet<SalesRow> SalesRow { get; set; }
        public virtual DbSet<TbItem> TbItem { get; set; }
        public virtual DbSet<TbSupplier> TbSupplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PSHD8LV;Initial Catalog=SalesAPI;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesHeader>(entity =>
            {
                entity.HasKey(e => e.HsalesId);

                entity.Property(e => e.HsalesId)
                    .HasColumnName("HSalesId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalesRow>(entity =>
            {
                entity.HasKey(e => e.RsalesId);

                entity.Property(e => e.RsalesId).HasColumnName("RSalesId");

                entity.Property(e => e.HsalesId).HasColumnName("HSalesId");
            });

            modelBuilder.Entity<TbItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uomid).HasColumnName("UOMId");

                entity.Property(e => e.Uomname)
                    .HasColumnName("UOMName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbSupplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
