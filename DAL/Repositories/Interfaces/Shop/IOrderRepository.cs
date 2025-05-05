using DAL.Entities.Shop;

namespace DAL.Repositories.Interfaces.Shop
{
    public interface IOrderRepository
    {
        int CreateOrder(Order entity);
        int UpdateOrder(Order entity);
        int DeleteOrder(int id);
        IQueryable<Order> GetAllOrders();
    }
}
