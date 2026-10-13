using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataModel;

[Index("CategoryId", Name = "IX_Products_CategoryId")]
[Index("Sku", Name = "UQ_Products_SKU", IsUnique = true)]
public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    [StringLength(150)]
    public string ProductName { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("SKU")]
    [StringLength(50)]
    public string Sku { get; set; } = null!;

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Product")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
