using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Order")]
[Index("ConsumerId", Name = "IX_Order_ConsumerID")]
[Index("FarmerId", Name = "IX_Order_FarmerID")]
public partial class Order
{
    [Key]
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal TotalPrice { get; set; }

    [StringLength(250)]
    public string Status { get; set; } = null!;

    [Column("ConsumerID")]
    public int ConsumerId { get; set; }

    [Column("FarmerID")]
    public int FarmerId { get; set; }

    [StringLength(250)]
    public string PaymentMethod { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    [StringLength(250)]
    public string Neighborhood { get; set; } = null!;

    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(250)]
    public string City { get; set; } = null!;

    [StringLength(250)]
    public string Street { get; set; } = null!;

    [StringLength(250)]
    public string HouseNum { get; set; } = null!;

    [ForeignKey("ConsumerId")]
    [InverseProperty("Orders")]
    public virtual Consumer Consumer { get; set; } = null!;

    [ForeignKey("FarmerId")]
    [InverseProperty("Orders")]
    public virtual Farmer Farmer { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("ProductId")]
    [InverseProperty("Orders")]
    public virtual Product Product { get; set; } = null!;
}
