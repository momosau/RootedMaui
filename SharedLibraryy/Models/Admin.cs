using System;
using System.Collections.Generic;

namespace SharedLibraryy.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public virtual ICollection<FarmerApplication> FarmerApplications { get; set; } = new List<FarmerApplication>();
}
