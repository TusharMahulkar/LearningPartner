using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopWebApplication.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
        
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
      
        public string Sku { get; set; } = null!;
      
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public bool IsActive { get; set; }
    }
}
