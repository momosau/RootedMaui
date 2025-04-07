using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Farmer")]
public partial class Farmer
{
    [Key]
    [Column("FarmerID")]
    public int FarmerId { get; set; }

    [StringLength(250)]
    public string Description { get; set; } = null!;

    [StringLength(250)]
    public string Certificate { get; set; } = null!;

    [StringLength(250)]
    public string City { get; set; } = null!;

    [Column("ImageURL")]
    [StringLength(250)]
    public string ImageUrl { get; set; } = null!;

    [StringLength(250)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [StringLength(250)]
    public string Password { get; set; } = null!;

    [StringLength(250)]
    public string VerificationStatus { get; set; } = null!;

    [StringLength(250)]
    public string UserName { get; set; } = null!;

    [StringLength(250)]
    public string FarmName { get; set; } = null!;

    [StringLength(250)]
    public string? Neighborhood { get; set; }

    [StringLength(250)]
    public string? Street { get; set; }

    public int? FarmNum { get; set; }

    [InverseProperty("Farmer")]
    public virtual ICollection<FarmerApplication> FarmerApplications { get; set; } = new List<FarmerApplication>();

    [InverseProperty("Farmer")]
    public virtual ICollection<FarmerSpecification> FarmerSpecifications { get; set; } = new List<FarmerSpecification>();

    [InverseProperty("Farmer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Farmer")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [InverseProperty("Farmer")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
