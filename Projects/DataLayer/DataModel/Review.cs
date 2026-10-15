using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataModel;

[Index("ProductId", Name = "IX_Reviews_ProductId")]
[Index("CustomerId", "ProductId", Name = "UQ_Reviews_Customer_Product", IsUnique = true)]
public partial class Review
{
    [Key]
    public int ReviewId { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public int Rating { get; set; }

    [StringLength(1000)]
    public string? Comment { get; set; }

    public DateTime ReviewDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Reviews")]
    public virtual Product Product { get; set; } = null!;
}
