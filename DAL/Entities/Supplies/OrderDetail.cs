namespace DAL.Entities.Supplies
{
    public class OrderDetail : BaseEntity
    {
        public int SupplyId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public Supply Supply { get; set; }
        public Order Order { get; set; }
    }
}
