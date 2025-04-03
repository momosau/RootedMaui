using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibraryy.Models;

[Table("Consumer")]
public partial class Consumer
{
    [Key]
    [Column("ConsumerID")]
    public int ConsumerId { get; set; }

    [StringLength(250)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(250)]
    public string City { get; set; } = null!;

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [StringLength(250)]
    public string Password { get; set; } = null!;

    [StringLength(250)]
    public string UserNamer { get; set; } = null!;

    [StringLength(250)]
    public string Neighborhood { get; set; } = null!;

    [StringLength(250)]
    public string Street { get; set; } = null!;

    [StringLength(250)]
    public string HouseNum { get; set; } = null!;

    [InverseProperty("Consumer")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [InverseProperty("Consumer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Consumer")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
