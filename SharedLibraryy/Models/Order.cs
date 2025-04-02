using System;
using System.Collections.Generic;

namespace SharedLibraryy.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public int ConsumerId { get; set; }

    public int FarmerId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public virtual Consumer Consumer { get; set; } = null!;

    public virtual Farmer Farmer { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
