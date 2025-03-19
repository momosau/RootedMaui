using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

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

    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string PaymentMethod { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string ShippingAddress { get; set; } = null!;

    public int? StatusShpinng { get; set; }

    [ForeignKey("ConsumerId")]
    [InverseProperty("Orders")]
    public virtual Consumer Consumer { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Orders")]
    public virtual Product Product { get; set; } = null!;
}
