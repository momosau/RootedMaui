using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Admin")]
public partial class Admin
{
    [Key]
    [Column("AdminID")]
    public int AdminId { get; set; }

    [StringLength(250)]
    public string Password { get; set; } = null!;

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [StringLength(250)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string UserName { get; set; } = null!;

    [InverseProperty("Admin")]
    public virtual ICollection<FarmerApplication> FarmerApplications { get; set; } = new List<FarmerApplication>();
}
