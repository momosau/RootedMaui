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
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [InverseProperty("VerifiedByAdmin")]
    public virtual ICollection<Farmer> Farmers { get; set; } = new List<Farmer>();
}
