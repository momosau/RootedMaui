using System;
using System.Collections.Generic;

namespace SharedLibraryy.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public double Weight { get; set; }

    public string Category { get; set; } = null!;

    public int Quantity { get; set; }

    public string? Description { get; set; }

    public double Price { get; set; }

    public string? ImageUrl { get; set; }

    public int FarmerId { get; set; }

    public int CategoryId { get; set; }

    public string Unit { get; set; } = null!;
   // public string FarmName { get; set; } = null!;   

    public virtual Category CategoryNavigation { get; set; } = null!;

    public virtual Farmer Farmer { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Specification> Specifications { get; set; } = new List<Specification>();
}
