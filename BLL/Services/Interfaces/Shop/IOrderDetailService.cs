using DAL.Entities.Shop;

namespace BLL.Services.Interfaces.Shop
{
    public interface IOrderDetailService
    {
        void CreateOrderDetail(OrderDetail entity);
        void UpdateOrderDetail(OrderDetail entity);
        void DeleteOrderDetail(int id);
        ICollection<OrderDetail> GetAllOrderDetails();
    }
}
