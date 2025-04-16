using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("FarmerApplication")]
public partial class FarmerApplication
{
    [Key]
    [Column("AppilicationID")]
    public int AppilicationId { get; set; }

  

    [Column("AdminID")]
    public int AdminId { get; set; }

    public DateOnly SubmitDate { get; set; }
    [StringLength(255)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Certificate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? City { get; set; }

    [Column("ImageURL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ImageUrl { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Password { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public bool? VerificationStatus { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UserName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? FarmName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Neighborhood { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Street { get; set; }

    public int? FarmNum { get; set; }

    [ForeignKey("AdminId")]
    [InverseProperty("FarmerApplications")]
    public virtual Admin Admin { get; set; } = null!;



    [ForeignKey("FarmerApplicationId")]
    public ICollection<Specification> Specifications { get; set; } = new List<Specification>();
}
