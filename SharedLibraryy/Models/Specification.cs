using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibraryy.Models;

[Table("Specification")]
public partial class Specification
{
    [Key]
    [Column("SpecificationID")]
    public int SpecificationId { get; set; }

    public bool? IsOrganic { get; set; }

    [Column("IsGMOFree")]
    public bool? IsGmofree { get; set; }

    public bool? IsHydroponicallyGrown { get; set; }
    public bool? IsLocal { get; set; }

    public bool? IsPesticideFree { get; set; }

    [ForeignKey("SpecificationId")]
    public virtual ICollection<Farmer> Farmers { get; set; } = new List<Farmer>();
    [ForeignKey("SpecificationId")]
    public ICollection<FarmerApplication> FarmerApplications { get; set; } = new List<FarmerApplication>();


    [ForeignKey("SpecificationId")]
    [InverseProperty("Specifications")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
