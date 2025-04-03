using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("FarmerSpecification")]
public partial class FarmerSpecification
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("FarmerID")]
    public int FarmerId { get; set; }

    [Column("SpecificationID")]
    public int SpecificationId { get; set; }

    [ForeignKey("FarmerId")]
    [InverseProperty("FarmerSpecifications")]
    public virtual Farmer Farmer { get; set; } = null!;

    [ForeignKey("SpecificationId")]
    [InverseProperty("FarmerSpecifications")]
    public virtual Specification Specification { get; set; } = null!;
}
