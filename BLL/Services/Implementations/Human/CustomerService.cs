using BLL.Services.Interfaces.Human;
using BLL.Utilities;
using DAL.Entities.Human;
using DAL.Repositories.Interfaces.Human;
using DTOs.Human;
using Microsoft.Extensions.Configuration;

namespace BLL.Services.Implementations.Human
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly string jwtSecret;

        public CustomerService(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            this.customerRepository = customerRepository;
            this.jwtSecret = configuration["Jwt:SecretKey"];
        }

        public CustomerService() { }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            var customer = customerRepository.GetCustomerByEmail(loginRequest.Email);
            if (customer == null) return null;

            bool isPasswordValid = PasswordUtil.VerifyPassword(loginRequest.Password, customer.Password);
            if (!isPasswordValid) return null;
            
            string token = JwtTokenUtil.GenerateToken(customer.Email, customer.Name, jwtSecret);
            return new LoginResponse { Token = token };
        }

        public void Register(Customer customer)
        {
            string hashedPassword = PasswordUtil.HashPassword(customer.Password);
            customer.Password = hashedPassword;
            customerRepository.CreateCustomer(customer);
        }
    }
}
