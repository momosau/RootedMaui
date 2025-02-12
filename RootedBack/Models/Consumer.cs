using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RootedBack.Models;

[Table("Consumer")]
public partial class Consumer
{
    [Key]
    [Column("ConsumerID")]
    public int ConsumerId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Location { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string UserNamer { get; set; } = null!;

    [InverseProperty("Consumer")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [InverseProperty("Consumer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Consumer")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
