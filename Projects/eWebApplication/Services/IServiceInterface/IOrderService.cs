using eShopWebApplication.Models;

namespace eShopWebApplication.Services.IServiceInterface
{
    public interface IOrderService
    {
        public void CreateOrder(OrderModel model);

        public void GetOrderByOrderId(int orderId);

        public void GetAllOrdersByCustomerId(int custoemrId);

        public void DeleteOrder(int orderId);
    }
}
