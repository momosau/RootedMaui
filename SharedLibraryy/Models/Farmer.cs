using System;
using System.Collections.Generic;

namespace SharedLibraryy.Models;

public partial class Farmer
{
    public int FarmerId { get; set; }

    public string Description { get; set; } = null!;

    public string Certificate { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string VerificationStatus { get; set; } = null!;

    public int VerifiedByAdminId { get; set; }

    public string UserName { get; set; } = null!;

    public string FarmName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Admin VerifiedByAdmin { get; set; } = null!;
}
