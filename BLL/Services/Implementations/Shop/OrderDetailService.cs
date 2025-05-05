using BLL.Services.Interfaces.Shop;
using DAL.Entities.Shop;

namespace BLL.Services.Implementations.Shop
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailService orderDetailService;

        public OrderDetailService(IOrderDetailService orderDetailService)
        {
            this.orderDetailService = orderDetailService;
        }

        public OrderDetailService() { }

        public void CreateOrderDetail(OrderDetail entity)
        {
            orderDetailService.CreateOrderDetail(entity);
        }

        public void DeleteOrderDetail(int id)
        {
            orderDetailService.DeleteOrderDetail(id);
        }

        public void UpdateOrderDetail(OrderDetail entity)
        {
            orderDetailService.UpdateOrderDetail(entity);
        }

        public ICollection<OrderDetail> GetAllOrderDetails()
        {
            return orderDetailService.GetAllOrderDetails();
        }
    }
}
