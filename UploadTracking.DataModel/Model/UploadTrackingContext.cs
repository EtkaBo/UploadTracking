using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UploadTracking.DataModel.Model
{
    public partial class UploadTrackingContext : DbContext
    {
        public UploadTrackingContext()
        {
        }

        public UploadTrackingContext(DbContextOptions<UploadTrackingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StoreIntegration> StoreIntegration { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("");
            }
        }
        //"Server=.\\;Database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreIntegration>(entity =>
            {
                entity.Property(e => e.StoreId).IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}
