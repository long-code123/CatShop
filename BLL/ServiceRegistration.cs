using BLL.Services.Implementations.Human;
using BLL.Services.Interfaces.Human;
using DAL.Repositories.Implementations.Human;
using DAL.Repositories.Implementations.Pet;
using DAL.Repositories.Implementations.Shop;
using DAL.Repositories.Interfaces.Human;
using DAL.Repositories.Interfaces.Pet;
using DAL.Repositories.Interfaces.Shop;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region ServiceRegister
            services.AddScoped<ICustomerService, CustomerService>();
            
            #endregion

            #region RepositoryRegister
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            
            services.AddScoped<ICatRepository, CatRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIsLoveRepository, IsLoveRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<ISupplyRepository, SupplyRepository>();
            #endregion
        }
    }
}
