using System.Text.Json.Serialization;

namespace SharedLibraryy.Models;

public partial class Specification
{
    public int SpecificationId { get; set; }

    [JsonPropertyName("isOrganic")]
    public bool IsOrganic { get; set; }

    [JsonPropertyName("isGmofree")]
    public bool IsGmofree { get; set; }

    [JsonPropertyName("isHydroponicallyGrown")]
    public bool IsHydroponicallyGrown { get; set; }

    [JsonPropertyName("isPesticideFree")]
    public bool IsPesticideFree { get; set; }

    [JsonPropertyName("isLocal")]
    public bool IsLocal { get; set; }

    public int? FarmerId { get; set; }

    public int? ProductId { get; set; }

    public int? FarmerApplicationId { get; set; }

    public virtual Farmer? Farmer { get; set; }

    public virtual FarmerApplication? FarmerApplication { get; set; }

    public virtual Product? Product { get; set; }
}
