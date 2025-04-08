using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Product")]
[Index("FarmerId", Name = "IX_Product_FarmerID")]
public partial class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(250)]
    public string Name { get; set; } = null!;

    public double Weight { get; set; }

    [StringLength(250)]
    public string Category { get; set; } = null!;

    public int Quantity { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }

    public double Price { get; set; }

    [Column("ImageURL")]
    [StringLength(250)]
    public string? ImageUrl { get; set; }

    [Column("FarmerID")]
    public int FarmerId { get; set; }

    public int CategoryId { get; set; }

    [StringLength(50)]
    public string Unit { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category CategoryNavigation { get; set; } = null!;

    [ForeignKey("FarmerId")]
    [InverseProperty("Products")]
    public virtual Farmer Farmer { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Product")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("ProductId")]
    [InverseProperty("Products")]
    public virtual ICollection<Specification> Specifications { get; set; } = new List<Specification>();
    [NotMapped]
    private bool _isInCart;
    [NotMapped]
    public bool IsInCart
    {
        get => _isInCart;
        set
        {
            if (_isInCart != value)
            {
                _isInCart = value;
                OnPropertyChanged(nameof(IsInCart));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

