using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataModel;

[Index("CustomerId", Name = "IX_Addresses_CustomerId")]
public partial class Address
{
    [Key]
    public int AddressId { get; set; }

    public int CustomerId { get; set; }

    [StringLength(200)]
    public string AddressLine { get; set; } = null!;

    [StringLength(100)]
    public string City { get; set; } = null!;

    [StringLength(100)]
    public string State { get; set; } = null!;

    [StringLength(12)]
    public string PostalCode { get; set; } = null!;

    [StringLength(100)]
    public string Country { get; set; } = null!;

    public bool IsDefault { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Addresses")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Address")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
