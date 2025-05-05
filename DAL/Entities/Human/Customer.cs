using DAL.Constants;
using DAL.Entities.Pet;
using DAL.Entities.Shop;

namespace DAL.Entities.Human
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginType LoginType { get; set; }

        public ICollection<IsLove> IsLoves { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
