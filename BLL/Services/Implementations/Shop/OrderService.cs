using BLL.Services.Interfaces.Shop;
using DAL.Entities.Shop;

namespace BLL.Services.Implementations.Shop
{
    public class OrderService : IOrderService
    {
        private readonly IOrderService orderService;

        public OrderService(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public OrderService() { }

        public void CreateOrder(Order entity)
        {
            orderService.CreateOrder(entity);
        }

        public void DeleteOrder(int id)
        {
            orderService.DeleteOrder(id);
        }
        public void UpdateOrder(Order entity)
        {
            orderService.UpdateOrder(entity);
        }

        public ICollection<Order> GetAllOrders()
        {
            return orderService.GetAllOrders();
        }
    }
}
