using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootedApi.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public double Weight { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Category { get; set; } = null!;

    public int Quantity { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? Description { get; set; }

    public double Price { get; set; }

    [Column("ImageURL")]
    [StringLength(250)]
    [Unicode(false)]
    public string? ImageUrl { get; set; }

    [Column("FarmerID")]
    public int FarmerId { get; set; }

    [ForeignKey("FarmerId")]
    [InverseProperty("Products")]
    public virtual Farmer Farmer { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("ProductId")]
    [InverseProperty("Products")]
    public virtual ICollection<Specification> Specifications { get; set; } = new List<Specification>();
}
