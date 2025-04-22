using DAL.Entities.Human;

namespace BLL.Services.Interfaces
{
    public interface ICustomerService
    {
        void Register(Customer customer);
        Customer LoginRequest(string email, string password);
        string LoginResponse(string email, string password);
    }
}
