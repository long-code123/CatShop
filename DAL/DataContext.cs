using DAL.Configurations;
using DAL.Entities.Human;
using DAL.Entities.Pet;
using DAL.Entities.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        #region DbSets

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<IsLove> IsLoves { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Supply> Supplies { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Presentation"))
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("CatShopConnectionSQLServer"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configurations = typeof(DataContext).Assembly.ExportedTypes
                .Where(type => typeof(IEntityConfiguration).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                .Select(type => (IEntityConfiguration)Activator.CreateInstance(type))
                .ToList();

            foreach (var configuration in configurations)
            {
                configuration.OnModelCreating(modelBuilder);
            }
        }
    }
}
