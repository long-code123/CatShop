using DAL.Entities.Supplies;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.Supplies
{
    public class OrderConfiguration : IEntityConfiguration
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders").HasKey(order => order.Id);

                entity.Property(order => order.Id).UseIdentityColumn(1, 1);

                entity.HasOne(order => order.Customer)
                    .WithMany(customer => customer.Orders)
                    .HasForeignKey(order => order.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
