namespace DAL.Entities
{
    public class IsLove : BaseEntity
    {
        public int CatId { get; set; }
        public int CustomerId { get; set; }

        public Cat Cat { get; set; }
        public Customer Customer { get; set; }
    }
}
