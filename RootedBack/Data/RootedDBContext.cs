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

    public virtual DbSet<Consumer> Consumers { get; set; }

    public virtual DbSet<Farmer> Farmers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-JAJ6P55J\\\\SQLEXPRESS;Database=RootedDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.Property(e => e.Email).IsFixedLength();
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK_CArt");

            entity.HasOne(d => d.Consumer).WithMany(p => p.Carts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Consumer_cart");
        });

        modelBuilder.Entity<Farmer>(entity =>
        {
            entity.Property(e => e.VerificationStatus).HasDefaultValue("Pending");

            entity.HasOne(d => d.VerifiedByAdmin).WithMany(p => p.Farmers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farmer_Admin");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.Consumer).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Consumer_Order");

            entity.HasOne(d => d.Farmer).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Farmer_order");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.PaymentId).ValueGeneratedNever();

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_Payment");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).ValueGeneratedNever();

            entity.HasOne(d => d.Farmer).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Farmer_Prooduct");

            entity.HasMany(d => d.Specifications).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductSpecification",
                    r => r.HasOne<Specification>().WithMany()
                        .HasForeignKey("SpecificationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Sepcification_Product"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Product_Specification"),
                    j =>
                    {
                        j.HasKey("ProductId", "SpecificationId").HasName("PK__ProductS__7E348A2CA8112B49");
                        j.ToTable("ProductSpecifications");
                        j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");
                        j.IndexerProperty<int>("SpecificationId").HasColumnName("SpecificationID");
                    });
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.ReviewId).ValueGeneratedNever();
            entity.Property(e => e.Comment).IsFixedLength();

            entity.HasOne(d => d.Consumer).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_Consumer");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product_Review");
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.Property(e => e.ShippingId).ValueGeneratedNever();

            entity.HasOne(d => d.Order).WithMany(p => p.Shippings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_Shipping");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.Property(e => e.SpecificationId).ValueGeneratedNever();
        });
        modelBuilder.Entity<Product>()
          .HasOne(p => p.Category)
          .WithMany()
          .HasForeignKey(p => p.CategoryId);


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
      
    }
