using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SharedLibraryy.Models;


namespace RootedBack.Data;

public partial class RootedDBContext : DbContext
{
    public RootedDBContext()
    {
    }

    public RootedDBContext(DbContextOptions<RootedDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Consumer> Consumers { get; set; }

    public virtual DbSet<Farmer> Farmers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-JAJ6P55J\\SQLEXPRESS01;Database=RootedDB1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E84F1C5ADD");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7971994E889");

            entity.HasOne(d => d.Consumer).WithMany(p => p.Carts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Consumer");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2BB32FD215");
        });

        modelBuilder.Entity<Consumer>(entity =>
        {
            entity.HasKey(e => e.ConsumerId).HasName("PK__Consumer__63BBE99AE94399EC");
        });

        modelBuilder.Entity<Farmer>(entity =>
        {
            entity.HasKey(e => e.FarmerId).HasName("PK__Farmer__731B88E8B91603B4");

            entity.Property(e => e.VerificationStatus).HasDefaultValue("Pending");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.Consumer).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Consumer");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Product");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A58EA1E90FD");

            entity.Property(e => e.PaymentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).ValueGeneratedNever();

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Farmer).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Farmer");

            entity.HasMany(d => d.Specifications).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductSpecification",
                    r => r.HasOne<Specification>().WithMany()
                        .HasForeignKey("SpecificationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductSpecifications_Specification"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductSpecifications_Product"),
                    j =>
                    {
                        j.HasKey("ProductId", "SpecificationId").HasName("PK__ProductS__7E348A2C3C9A37B0");
                        j.ToTable("ProductSpecifications");
                        j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");
                        j.IndexerProperty<int>("SpecificationId").HasColumnName("SpecificationID");
                    });
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79AE5A1F0831");

            entity.HasOne(d => d.Consumer).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Consumer");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.HasKey(e => e.SpecificationId).HasName("PK__Specific__A384CC1D1928F5E4");

            entity.Property(e => e.SpecificationId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
