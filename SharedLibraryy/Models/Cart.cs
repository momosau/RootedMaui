using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Cart")]
[Index("ConsumerId", Name = "IX_Cart_ConsumerID")]
public partial class Cart
{
    [Key]
    [Column("CartID")]
    public int CartId { get; set; }

    [Column("ConsumerID")]
    public int? ConsumerId { get; set; } 
    [Column(TypeName = "decimal(18, 0)")]
    public decimal Price { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    [NotMapped]
    public decimal Amount => Price * Quantity;

    public int Quantity { get; set; }

    [ForeignKey("ConsumerId")]
    [InverseProperty("Carts")]
    public virtual Consumer Consumer { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Carts")]
    public virtual Product Product { get; set; } = null!;
}
