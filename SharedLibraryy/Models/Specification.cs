using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibraryy.Models;

[Table("Specification")]
public partial class Specification
{
    public int SpecificationId { get; set; }

    public bool? IsOrganic { get; set; }

    public bool? IsGmofree { get; set; }

    public bool? IsHydroponicallyGrown { get; set; }

    public bool? IsPesticideFree { get; set; }

    public bool? IsLocal { get; set; }

    public int? FarmerId { get; set; }

    public int? ProductId { get; set; }

    public int? FarmerApplicationId { get; set; }

    public virtual Farmer? Farmer { get; set; }

    public virtual FarmerApplication? FarmerApplication { get; set; }

    public virtual Product? Product { get; set; }
}
