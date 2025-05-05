using DAL.Constants;
using DAL.Entities.Human;

namespace DAL.Entities.Shop
{
    public class Order : BaseEntity
    {
        public int? CustomerId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }        
    }
}
