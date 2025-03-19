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
    public string Location { get; set; } = null!;

    [Column("ImageURL")]
    [StringLength(250)]
    public string? ImageUrl { get; set; }

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

    [InverseProperty("Farmer")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
