using System;
using System.Collections.Generic;

namespace SharedLibraryy.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int ConsumerId { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Consumer Consumer { get; set; } = null!;
}
