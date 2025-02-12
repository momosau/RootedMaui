using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootedBack.Models;

[Table("Review")]
public partial class Review
{
    [Column("ConsumerID")]
    public int ConsumerId { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Rating { get; set; }

    [StringLength(10)]
    public string Comment { get; set; } = null!;

    [Key]
    [Column("ReviewID")]
    public int ReviewId { get; set; }

    [ForeignKey("ConsumerId")]
    [InverseProperty("Reviews")]
    public virtual Consumer Consumer { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Reviews")]
    public virtual Product Product { get; set; } = null!;
}
