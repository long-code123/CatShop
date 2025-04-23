using BLL.Services.Implementations.Human;
using BLL.Services.Interfaces.Human;
using DAL.Repositories.Implementations.Human;
using DAL.Repositories.Implementations.Pet;
using DAL.Repositories.Interfaces.Human;
using DAL.Repositories.Interfaces.Pet;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<ICatRepository, CatRepository>();
        }
    }
}
