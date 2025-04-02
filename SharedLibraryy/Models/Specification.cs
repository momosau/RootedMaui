using System;
using System.Collections.Generic;

namespace SharedLibraryy.Models;

public partial class Specification
{
    public int SpecificationId { get; set; }

    public bool? IsLocal { get; set; }

    public bool? IsOrganic { get; set; }

    public bool? IsGmofree { get; set; }

    public bool? IsHydroponicallyGrown { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
