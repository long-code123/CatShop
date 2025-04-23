using BLL.Services.Interfaces.Human;
using BLL.Utilities;
using DAL.Entities.Human;
using DAL.Repositories.Interfaces.Human;
using DTOs.Human;

namespace BLL.Services.Implementations.Human
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public CustomerService() { }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            Customer customer = customerRepository.GetCustomerByEmail(loginRequest.Email);
            bool isPasswordValid = PasswordUtil.VerifyPassword(loginRequest.Password, customer.Password);
            if (isPasswordValid)
            {
                return new LoginResponse{ Name = customer.Name };
            }
            else return null;
        }

        public void Register(Customer customer)
        {
            string hashedPassword = PasswordUtil.HashPassword(customer.Password);
            customer.Password = hashedPassword;
            customerRepository.CreateCustomer(customer);
        }
    }
}
