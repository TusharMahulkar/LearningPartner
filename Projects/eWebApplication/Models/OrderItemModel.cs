using DataLayer.DataModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopWebApplication.Models
{
    public class OrderItemModel
    {
        public int OrderItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

    }
}
