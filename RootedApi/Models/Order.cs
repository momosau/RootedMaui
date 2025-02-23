using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootedApi.Models;

[Table("Order")]
public partial class Order
{
    [Key]
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal TotalPrice { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("ConsumerID")]
    public int ConsumerId { get; set; }

    [Column("FarmerID")]
    public int FarmerId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string PaymentMethod { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string ShippingAddress { get; set; } = null!;

    [ForeignKey("ConsumerId")]
    [InverseProperty("Orders")]
    public virtual Consumer Consumer { get; set; } = null!;

    [ForeignKey("FarmerId")]
    [InverseProperty("Orders")]
    public virtual Farmer Farmer { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [InverseProperty("Order")]
    public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();
}
