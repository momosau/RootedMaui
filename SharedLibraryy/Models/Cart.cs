using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Cart")]
[Index("ConsumerId", Name = "IX_Cart_ConsumerID")]
public partial class Cart : INotifyPropertyChanged
{
    [Key]
    [Column("CartID")]
    public int CartId { get; set; }

    [Column("ConsumerID")]
    public int ConsumerId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Price { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    private decimal _amount;
    [Column(TypeName = "decimal(18, 0)")]
    public decimal Amount
    {
        get => _amount;
        set
        {
            if (_amount != value)
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
    }

    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                Amount = Price * _quantity; // Automatically update Amount
            }
        }
    }

    [ForeignKey("ConsumerId")]
    [InverseProperty("Carts")]
    public virtual Consumer Consumer { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Carts")]
    public virtual Product Product { get; set; } = null!;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
