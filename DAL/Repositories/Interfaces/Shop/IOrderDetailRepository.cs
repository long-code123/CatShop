using DAL.Entities.Shop;

namespace DAL.Repositories.Interfaces.Shop
{
    public interface IOrderDetailRepository
    {
        int CreateOrderDetail(OrderDetail entity);
        int UpdateOrderDetail(OrderDetail entity);
        int DeleteOrderDetail(int id);
        IQueryable<OrderDetail> GetAllOrderDetails();
    }
}
