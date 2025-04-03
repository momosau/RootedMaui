using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Category")]
public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(50)]
    public string CategoryName { get; set; } = null!;

    [StringLength(250)]
    public string? ImagesUrl { get; set; }

    [InverseProperty("CategoryNavigation")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
