using DAL.Entities.Human;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.Human
{
    public class CustomerConfiguration : IEntityConfiguration
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers").HasKey(customer => customer.Id);

                entity.Property(customer => customer.Id).UseIdentityColumn(1, 1);
            });
        }
    }
}
