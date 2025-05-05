using DAL.Entities.Shop;
using DAL.Repositories.Interfaces.Shop;

namespace DAL.Repositories.Implementations.Shop
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DataContext dataContext;

        public OrderDetailRepository() { }

        public OrderDetailRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int CreateOrderDetail(OrderDetail entity)
        {
            dataContext.Add(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int UpdateOrderDetail(OrderDetail entity)
        {
            dataContext.Update(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int DeleteOrderDetail(int id)
        {
            OrderDetail orderDetail = dataContext.OrderDetails.Where(order => order.Id == id).FirstOrDefault();
            dataContext.OrderDetails.Remove(orderDetail);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public IQueryable<OrderDetail> GetAllOrderDetails()
        {
            IQueryable<OrderDetail> orderDetails = dataContext.OrderDetails;

            return orderDetails;
        }
    }
}
