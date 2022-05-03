using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PoReleaseApi.Models
{
    public partial class PoReleaseContext : DbContext
    {
        public PoReleaseContext()
        {
        }

        public PoReleaseContext(DbContextOptions<PoReleaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<PoRelease> PoReleases { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PoRelease;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<PoRelease>(entity =>
            {
                entity.ToTable("PoRelease");

                entity.Property(e => e.AdditionalNotes).HasColumnName("additionalNotes");

                entity.Property(e => e.AreaManagerEmail)
                    .HasMaxLength(100)
                    .HasColumnName("areaManagerEmail");

                entity.Property(e => e.Attachment).HasColumnName("attachment");

                entity.Property(e => e.CancellationPolicy)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CustomerCancellationTerms)
                    .HasMaxLength(100)
                    .HasColumnName("customerCancellationTerms");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .HasColumnName("customerName");

                entity.Property(e => e.HighUrgency)
                    .HasMaxLength(100)
                    .HasColumnName("highUrgency");

                entity.Property(e => e.IsAvailableInCompany).HasColumnName("isAvailableInCompany");

                entity.Property(e => e.IsCheckedDnowInventory).HasColumnName("isCheckedDnowInventory");

                entity.Property(e => e.IsCollaborateWithCorporateAndCentral).HasColumnName("isCollaborateWIthCorporateAndCentral");

                entity.Property(e => e.IsPoGreaterFiftyThousand).HasColumnName("isPoGreaterFiftyThousand");

                entity.Property(e => e.IsUsesItemCodes).HasColumnName("isUsesItemCodes");

                entity.Property(e => e.PoNumber)
                    .HasMaxLength(100)
                    .HasColumnName("poNumber");

                entity.Property(e => e.PoType)
                    .HasMaxLength(100)
                    .HasColumnName("poType");

                entity.Property(e => e.RequestReason)
                    .HasMaxLength(100)
                    .HasColumnName("requestReason");

                entity.Property(e => e.RequestingPlant)
                    .HasMaxLength(100)
                    .HasColumnName("requestingPlant");

                entity.Property(e => e.RestockingFees)
                    .HasMaxLength(100)
                    .HasColumnName("restockingFees");

                entity.Property(e => e.TotalPovalue).HasColumnName("totalPOValue");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .HasColumnName("vendorName");

                entity.Property(e => e.VendorReturnPolicy)
                    .HasMaxLength(100)
                    .HasColumnName("vendorReturnPolicy");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
