using DAL;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Installers
{
    public class DatabaseContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
