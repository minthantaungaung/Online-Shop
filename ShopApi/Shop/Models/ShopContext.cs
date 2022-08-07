using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shop.Models
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccRecover> AccRecover { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }
        public virtual DbSet<TimerLog> TimerLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KKT-BJRFK12\\SA;Database=Shop;User ID=sa;Password=mtaa123456789%%;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccRecover>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Accesstime).HasColumnType("datetime");

                entity.Property(e => e.ConfirmCode).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.StateDivision).HasMaxLength(50);

                entity.Property(e => e.Township).HasMaxLength(50);

                entity.Property(e => e.Ward).HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.Detail).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhotoUrl).HasMaxLength(50);

                entity.Property(e => e.Rating).HasMaxLength(50);

                entity.Property(e => e.Seller).HasMaxLength(50);

                entity.Property(e => e.ShopCode).HasMaxLength(50);
            });

            modelBuilder.Entity<Shops>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Latitiude).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.OwnerName).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.ShopCode).HasMaxLength(50);

                entity.Property(e => e.ShopName).HasMaxLength(50);

                entity.Property(e => e.ShopType).HasMaxLength(50);

                entity.Property(e => e.StateDivision).HasMaxLength(50);

                entity.Property(e => e.Township).HasMaxLength(50);

                entity.Property(e => e.Ward).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(50);
            });

            modelBuilder.Entity<TimerLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Accesstime).HasColumnType("datetime");

                entity.Property(e => e.ClosedDate).HasColumnType("datetime");

                entity.Property(e => e.MemberEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
