using DAL.Constants;
using DAL.Entities.Human;

namespace DAL.Entities.Supplies
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public Customer Customer { get; set; }
    }
}
