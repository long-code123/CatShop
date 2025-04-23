using BLL.Services.Interfaces.Human;
using DTOs.Human;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Human
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost("login")]
        public  ActionResult<LoginResponse> Login([FromBody] LoginRequest loginRequest)
        {
            var response = customerService.Login(loginRequest);
            if(response == null) return Unauthorized(new {message = "Wrong email or password"});

            return Ok(response);
        }
    }
}
