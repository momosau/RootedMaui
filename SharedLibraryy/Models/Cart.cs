using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Cart")]
public partial class Cart
{
    [Key]
    [Column("CartID")]
    public int CartId { get; set; }

    [Column("ConsumerID")]
    public int ConsumerId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal TotalPrice { get; set; }

    [ForeignKey("ConsumerId")]
    [InverseProperty("Carts")]
    public virtual Consumer Consumer { get; set; } = null!;
}
