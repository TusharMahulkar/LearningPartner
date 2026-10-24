using DataLayer.DataModel;

namespace eShopWebApplication.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; } = null!;

        public decimal TotalAmount { get; set; }

        public string? Notes { get; set; }

        public List<OrderItemModel> orderItems { get; set; }
    }
}
