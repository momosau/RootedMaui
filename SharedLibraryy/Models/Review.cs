using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Review")]
[Index("ConsumerId", Name = "IX_Review_ConsumerID")]
[Index("ProductId", Name = "IX_Review_ProductID")]
public partial class Review
{
    [Key]
    [Column("ReviewID")]
    public int ReviewId { get; set; }

    [Column("ConsumerID")]
    public int ConsumerId { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Rating { get; set; }

    [StringLength(250)]
    public string Comment { get; set; } = null!;

    [Column("FarmerID")]
    public int FarmerId { get; set; }

    [ForeignKey("ConsumerId")]
    [InverseProperty("Reviews")]
    public virtual Consumer Consumer { get; set; } = null!;

    [ForeignKey("FarmerId")]
    [InverseProperty("Reviews")]
    public virtual Farmer Farmer { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Reviews")]
    public virtual Product Product { get; set; } = null!;
}
