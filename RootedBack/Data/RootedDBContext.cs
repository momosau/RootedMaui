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

    // public virtual DbSet<FarmerSpecification> FarmerSpecifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-JAJ6P55J\\SQLEXPRESS01;Database=RootedDB1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK_CArt");

            entity.HasOne(d => d.Consumer).WithMany(p => p.Carts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Consumer_cart");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).ValueGeneratedNever();
        });



        modelBuilder.Entity<FarmerApplication>(entity =>
        {
            entity.HasOne(d => d.Admin).WithMany(p => p.FarmerApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminAplication");


        });
        modelBuilder.Entity<Farmer>()
            .HasMany(f => f.Specifications)
            .WithMany(s => s.Farmers)
            .UsingEntity<Dictionary<string, object>>(
                "FarmerSpecification",
                j => j.HasOne<Specification>().WithMany().HasForeignKey("SpecificationID"),
                j => j.HasOne<Farmer>().WithMany().HasForeignKey("FarmerID"),
                j =>
                {
                    j.HasKey("FarmerID", "SpecificationID");
                    j.ToTable("FarmerSpecification");
                }
            );
        modelBuilder.Entity<FarmerApplication>()
            .HasMany(fa => fa.Specifications)
            .WithMany(s => s.FarmerApplications);




        modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.HasOne(d => d.Consumer).WithMany(p => p.Orders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Consumer_Order");

                entity.HasOne(d => d.Farmer).WithMany(p => p.Orders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Farmer_order");

                entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Product");
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
            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryProduct");

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
                        j.HasIndex(new[] { "SpecificationId" }, "IX_ProductSpecifications_SpecificationID");
                        j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");
                        j.IndexerProperty<int>("SpecificationId").HasColumnName("SpecificationID");
                    });
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.ReviewId).ValueGeneratedNever();

            entity.HasOne(d => d.Consumer).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_Consumer");

            entity.HasOne(d => d.Farmer).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FarmerReview");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product_Review");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.Property(e => e.SpecificationId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
