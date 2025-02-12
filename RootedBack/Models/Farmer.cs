using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootedBack.Models;

[Table("Farmer")]
public partial class Farmer
{
    [Key]
    [Column("FarmerID")]
    public int FarmerId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Certificate { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Location { get; set; } = null!;

    [Column("ImageURL")]
    [StringLength(250)]
    [Unicode(false)]
    public string? ImageUrl { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string VerificationStatus { get; set; } = null!;

    public int VerifiedByAdminId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [InverseProperty("Farmer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Farmer")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [ForeignKey("VerifiedByAdminId")]
    [InverseProperty("Farmers")]
    public virtual Admin VerifiedByAdmin { get; set; } = null!;
}
