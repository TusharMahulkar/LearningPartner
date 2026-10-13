using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataModel;

[Index("Email", Name = "UQ_Customers_Email", IsUnique = true)]
public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(150)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string? Phone { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public int? CreatedBy { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Customer")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
