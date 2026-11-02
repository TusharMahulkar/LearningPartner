using DataLayer.DataModel;
using eShopWebApplication.Models;
using eShopWebApplication.Services.IServiceInterface;
using SQLDataLayer.Repository;

namespace eShopWebApplication.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<OrderItem> _orderItemRepository;
        public OrderService(IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository) 
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository; 
        }

        public void CreateOrder(OrderModel model)
        {
            //Create Order Id
            Order newOrder = new Order();             
            newOrder.CustomerId = model.CustomerId;
            newOrder.AddressId = model.AddressId;
            newOrder.OrderDate = model.OrderDate;
            newOrder.OrderStatus ="Pending";

            var isOrderCreated = _orderRepository.AddItem(newOrder);
            if(isOrderCreated)            
            {

                List<OrderItem> orderItems = new List<OrderItem>(); 

                //Create OrderItems
                foreach (var order in model.orderItems)
                {
                    OrderItem item = new OrderItem();
                    item.OrderId =   newOrder.OrderId;
                    item.ProductId = order.ProductId;
                    item.UnitPrice = order.UnitPrice;
                    item.Quantity = order.Quantity;

                    orderItems.Add(item);
                }

                if(orderItems.Any())
                {
                    var result = _orderItemRepository.BulkAddItems(orderItems);                     
                }
            }

        }

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public void GetAllOrdersByCustomerId(int custoemrId)
        {
            throw new NotImplementedException();
        }

        public void GetOrderByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

    }
}
