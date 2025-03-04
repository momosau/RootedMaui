using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Specification")]
public partial class Specification
{
    [Key]
    [Column("SpecificationID")]
    public int SpecificationId { get; set; }

    public bool? IsLocal { get; set; }

    public bool? IsOrganic { get; set; }

    [Column("IsGMOFree")]
    public bool? IsGmofree { get; set; }

    public bool? IsHydroponicallyGrown { get; set; }

    [ForeignKey("SpecificationId")]
    [InverseProperty("Specifications")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
