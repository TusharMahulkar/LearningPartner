using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataModel;

[Index("OrderId", Name = "IX_Payments_OrderId")]
public partial class Payment
{
    [Key]
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Amount { get; set; }

    [StringLength(30)]
    public string PaymentMethod { get; set; } = null!;

    [StringLength(20)]
    public string PaymentStatus { get; set; } = null!;

    [StringLength(100)]
    public string? TransactionReference { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Payments")]
    public virtual Order Order { get; set; } = null!;
}
