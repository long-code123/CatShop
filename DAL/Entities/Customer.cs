using DAL.Enums;

namespace DAL.Entities
{   
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginType LoginType { get; set; }
    }
}
