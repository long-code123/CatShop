using BLL.Services.Interfaces;
using DAL.Entities.Human;
using DAL.Repositories.Interfaces.Human;

namespace BLL.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public CustomerService() { }

        public Customer LoginRequest(string email, string password)
        {
            Customer customer = customerRepository.GetCustomerByEmail(email);
            return customer;
        }

        public string LoginResponse(string email, string password)
        {
            var customer = LoginRequest(email, password);

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, customer.Password);

            if (isPasswordValid)
            {
                return customer.Name;
            }
            else return "";

        }

        public void Register(Customer customer)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(customer.Password);
            customer.Password = hashedPassword;
            customerRepository.CreateCustomer(customer);
        }
    }
}
