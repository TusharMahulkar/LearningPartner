using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataModel;

[Index("CategoryName", Name = "UQ_Categories_CategoryName", IsUnique = true)]
public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(100)]
    public string CategoryName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
