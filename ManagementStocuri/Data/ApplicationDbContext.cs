using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ManagementStocuri.Models.DBObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ManagementStocuri.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedName] IS NOT NULL)");

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);

            //    entity.HasMany(d => d.Roles)
            //        .WithMany(p => p.Users)
            //        .UsingEntity<Dictionary<string, object>>(
            //            "AspNetUserRole",
            //            l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
            //            r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
            //            j =>
            //            {
            //                j.HasKey("UserId", "RoleId");

            //                j.ToTable("AspNetUserRoles");

            //                j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
            //            });
            //});

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.Name).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Idcustomer)
                    .HasName("PK__Customer__701C9C3CC814EE18");

                entity.ToTable("Customer");

                entity.Property(e => e.Idcustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCustomer");

                entity.Property(e => e.Adress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.Idoffer)
                    .HasName("PK__Offers__F1E50DFCFEB6A812");

                entity.Property(e => e.Idoffer)
                    .ValueGeneratedNever()
                    .HasColumnName("IDOffer");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Idorder)
                    .HasName("PK__Orders__5CBBCADBF0A53E6C");

                entity.Property(e => e.Idorder)
                    .ValueGeneratedNever()
                    .HasColumnName("IDOrder");

                entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");

                entity.Property(e => e.Idproduct).HasColumnName("IDProduct");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdcustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Idcustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customer");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Idproduct)
                    .HasName("PK__Products__4290D17929E8238A");

                entity.Property(e => e.Idproduct)
                    .ValueGeneratedNever()
                    .HasColumnName("IDProduct");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Idsupplier).HasColumnName("IDSupplier");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdsupplierNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Idsupplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Idsupplier)
                    .HasName("PK__Supplier__0851A1EDD671B614");

                entity.Property(e => e.Idsupplier)
                    .ValueGeneratedNever()
                    .HasColumnName("IDSupplier");

                entity.Property(e => e.Adress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
