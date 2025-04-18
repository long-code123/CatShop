using DAL.Enums;

namespace DAL.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public Customer Customer { get; set; }
    }
}
