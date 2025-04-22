using BLL.Services.Interfaces.Human;
using DAL.Entities.Human;
using DAL.Repositories.Interfaces.Human;
using DTOs.Human;
using DTOs.Utils;

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

        public LoginResponseDto Login(LoginRequestDto loginRequestDto)
        {
            Customer customer = customerRepository.GetCustomerByEmail(loginRequestDto.Email);
            bool isPasswordValid = PasswordUtil.VerifyPassword(loginRequestDto.Password, customer.Password);
            if (isPasswordValid)
            {
                return new LoginResponseDto { Name = customer.Name };
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
