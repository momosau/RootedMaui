using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Shipping")]
public partial class Shipping
{
    [Key]
    [Column("ShippingID")]
    public int ShippingId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string ShippingStatus { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string ShippingMethod { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Source { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Destination { get; set; } = null!;

    public int TrackingNumber { get; set; }

    [Column("OrderID")]
    public int OrderId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Shippings")]
    public virtual Order Order { get; set; } = null!;
}
