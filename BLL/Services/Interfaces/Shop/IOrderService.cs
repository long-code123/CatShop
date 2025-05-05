using DAL.Entities.Shop;

namespace BLL.Services.Interfaces.Shop
{
    public interface IOrderService
    {
        void CreateOrder(Order entity);
        void UpdateOrder(Order entity);
        void DeleteOrder(int id);
        ICollection<Order> GetAllOrders();
    }
}
