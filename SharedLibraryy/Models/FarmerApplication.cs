using System;
using System.Collections.Generic;

namespace SharedLibraryy.Models;

public partial class FarmerApplication
{
    public int ApplicationId { get; set; }

    public int AdminId { get; set; }

    public DateOnly SubmitDate { get; set; }

    public string Description { get; set; } = null!;

    public string? Certificate { get; set; }

    public string? City { get; set; }

    public string? ImageUrl { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool VerificationStatus { get; set; }

    public string? UserName { get; set; }

    public string? FarmName { get; set; }

    public string? Neighborhood { get; set; }

    public string? Street { get; set; }

    public int? FarmNum { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual Specification? Specification { get; set; }
}
