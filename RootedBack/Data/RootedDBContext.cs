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

    public virtual DbSet<FarmerApplication> FarmerApplications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(250);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK_CArt");

            entity.ToTable("Cart");

            entity.HasIndex(e => e.ConsumerId, "IX_Cart_ConsumerID");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Consumer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ConsumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Consumer_cart");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.ImagesUrl).HasMaxLength(250);
        });

        modelBuilder.Entity<Consumer>(entity =>
        {
            entity.ToTable("Consumer");

            entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");
            entity.Property(e => e.City).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.HouseNum).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Neighborhood).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.PhoneNumber).HasMaxLength(250);
            entity.Property(e => e.Street).HasMaxLength(250);
            entity.Property(e => e.UserNamer).HasMaxLength(250);
        });

        modelBuilder.Entity<Farmer>(entity =>
        {
            entity.ToTable("Farmer");

            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.Certificate).HasMaxLength(250);
            entity.Property(e => e.City).HasMaxLength(250);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FarmName).HasMaxLength(250);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(250)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Neighborhood).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.PhoneNumber).HasMaxLength(250);
            entity.Property(e => e.Street).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(250);
            entity.Property(e => e.VerificationStatus)
                .IsRequired()
                .HasDefaultValueSql("('Pending')");
        });

        modelBuilder.Entity<FarmerApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId);

            entity.ToTable("FarmerApplication");

            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.Certificate).HasMaxLength(255);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FarmName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Neighborhood)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Admin).WithMany(p => p.FarmerApplications)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminAplication");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.HasIndex(e => e.ConsumerId, "IX_Order_ConsumerID");

            entity.HasIndex(e => e.FarmerId, "IX_Order_FarmerID");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.City).HasMaxLength(250);
            entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.HouseNum).HasMaxLength(250);
            entity.Property(e => e.Neighborhood).HasMaxLength(250);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(250);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Status).HasMaxLength(250);
            entity.Property(e => e.Street).HasMaxLength(250);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Consumer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ConsumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Consumer_Order");

            entity.HasOne(d => d.Farmer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FarmerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Farmer_order");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Product");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.HasIndex(e => e.OrderId, "IX_Payment_OrderID");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(250);
            entity.Property(e => e.Status).HasMaxLength(250);

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_Payment");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.FarmerId, "IX_Product_FarmerID");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Category).HasMaxLength(250);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(250)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Unit).HasMaxLength(50);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryProduct");

            entity.HasOne(d => d.Farmer).WithMany(p => p.Products)
                .HasForeignKey(d => d.FarmerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Farmer_Prooduct");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.Question1)
                .HasMaxLength(250)
                .HasColumnName("Question");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79AE83B59E21");


            entity.HasIndex(e => e.ConsumerId, "IX_Review_ConsumerID");

            entity.HasIndex(e => e.ProductId, "IX_Review_ProductID");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Comment).HasMaxLength(250);
            entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Consumer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ConsumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_Consumer");

            entity.HasOne(d => d.Farmer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.FarmerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FarmerReview");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product_Review");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.ToTable("Specification");

            entity.HasIndex(e => e.FarmerApplicationId, "IX_Applocation").IsUnique();

            entity.HasIndex(e => e.FarmerId, "IX_Farmer").IsUnique();

            entity.HasIndex(e => e.ProductId, "IX_Product").IsUnique();

            entity.Property(e => e.SpecificationId)
                .ValueGeneratedNever()
                .HasColumnName("SpecificationID");
            entity.Property(e => e.IsGmofree).HasColumnName("IsGMOFree");

            entity.HasOne(d => d.FarmerApplication).WithOne(p => p.Specification)
                .HasForeignKey<Specification>(d => d.FarmerApplicationId)
                .HasConstraintName("FK_Specification_FarmerAPpliaction");

            entity.HasOne(d => d.Farmer).WithOne(p => p.Specification)
                .HasForeignKey<Specification>(d => d.FarmerId)
                .HasConstraintName("FK_Specification_Farmer");

            entity.HasOne(d => d.Product).WithOne(p => p.Specification)
                .HasForeignKey<Specification>(d => d.ProductId)
                .HasConstraintName("FK_Specification_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
