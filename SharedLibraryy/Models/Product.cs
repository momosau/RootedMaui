using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SharedLibraryy.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public double Weight { get; set; }

    public string Category { get; set; } = null!;

    public int Quantity { get; set; }

    public string? Description { get; set; }

    public double Price { get; set; }

    public string? ImageUrl { get; set; }

    public int FarmerId { get; set; }

    public int CategoryId { get; set; }

    public string Unit { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category CategoryNavigation { get; set; } = null!;

    public virtual Farmer Farmer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Specification? Specification { get; set; }
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
