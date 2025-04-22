using DAL.Entities.Human;
using DTOs.Human;

namespace BLL.Services.Interfaces.Human
{
    public interface ICustomerService
    {
        void Register(Customer customer);
        LoginResponseDto Login(LoginRequestDto loginRequestDto);
    }
}
