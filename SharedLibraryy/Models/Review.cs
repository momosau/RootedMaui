using System;
using System.Collections.Generic;

namespace SharedLibraryy.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int ConsumerId { get; set; }

    public int ProductId { get; set; }

    public decimal Rating { get; set; }

    public string Comment { get; set; } = null!;

    public virtual Consumer Consumer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
