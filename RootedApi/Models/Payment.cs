using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootedApi.Models;

[Table("Payment")]
public partial class Payment
{
    [Key]
    [Column("PaymentID")]
    public int PaymentId { get; set; }

    public double Amount { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string PaymentMethod { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime PaymentDate { get; set; }

    [Column("OrderID")]
    public int OrderId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Payments")]
    public virtual Order Order { get; set; } = null!;
}
