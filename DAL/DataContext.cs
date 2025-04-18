using DAL.Configurations;
using DAL.Entities.Human;
using DAL.Entities.Pet;
using DAL.Entities.Supplies;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supply> Supplies { get; set; }

        #endregion

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
