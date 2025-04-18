using System;
using System.Collections.Generic;

namespace SharedLibraryy.Models;

public partial class Farmer
{
    public int FarmerId { get; set; }

    public string Description { get; set; } = null!;

    public string Certificate { get; set; } = null!;

    public string City { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? VerificationStatus { get; set; }

    public string UserName { get; set; } = null!;

    public string FarmName { get; set; } = null!;

    public string? Neighborhood { get; set; }

    public string? Street { get; set; }

    public int? FarmNum { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Specification? Specification { get; set; }
}
