using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataModel;

[Index("CustomerId", "OrderDate", Name = "IX_Orders_CustomerId_OrderDate")]
public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int AddressId { get; set; }

    public DateTime OrderDate { get; set; }

    [StringLength(20)]
    public string OrderStatus { get; set; } = null!;

    [Column(TypeName = "decimal(12, 2)")]
    public decimal TotalAmount { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Orders")]
    public virtual Address Address { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Order")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
