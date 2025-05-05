using DAL.Entities.Shop;
using DAL.Repositories.Interfaces.Shop;

namespace DAL.Repositories.Implementations.Shop
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext dataContext;

        public OrderRepository() { }

        public OrderRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int CreateOrder(Order entity)
        {
            dataContext.Add(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int UpdateOrder(Order entity)
        {
            dataContext.Update(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int DeleteOrder(int id)
        {
            Order order = dataContext.Orders.Where(order => order.Id == id).FirstOrDefault();
            dataContext.Orders.Remove(order);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public IQueryable<Order> GetAllOrders()
        {
            IQueryable<Order> orders = dataContext.Orders;

            return orders;
        }
    }
}
