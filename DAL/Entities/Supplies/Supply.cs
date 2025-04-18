using DAL.Constants;

namespace DAL.Entities.Supplies
{
    public class Supply : BaseEntity
    {
        public TypeSupply TypeSupply { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
