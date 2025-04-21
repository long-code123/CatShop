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
        public void Seeding(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            modelBuilder.Entity<Order>().HasData(
                    new Order { Id = 1, CustomerId = 1, PaymentStatus = Constants.PaymentStatus.Cancelled, CreatedAt = now, UpdatedAt = now },
                    new Order { Id = 2, CustomerId = 2, PaymentStatus = Constants.PaymentStatus.Paid, CreatedAt = now, UpdatedAt = now },
                    new Order { Id = 3, CustomerId = 3, PaymentStatus = Constants.PaymentStatus.Pending, CreatedAt = now, UpdatedAt = now },
                    new Order { Id = 4, CustomerId = 4, PaymentStatus = Constants.PaymentStatus.Failed, CreatedAt = now, UpdatedAt = now },
                    new Order { Id = 5, CustomerId = 5, PaymentStatus = Constants.PaymentStatus.Failed, CreatedAt = now, UpdatedAt = now },
                    new Order { Id = 6, CustomerId = 6, PaymentStatus = Constants.PaymentStatus.Paid, CreatedAt = now, UpdatedAt = now },
                    new Order { Id = 7, CustomerId = 7, PaymentStatus = Constants.PaymentStatus.Pending, CreatedAt = now, UpdatedAt = now },
                    new Order { Id = 8, CustomerId = 8, PaymentStatus = Constants.PaymentStatus.Pending, CreatedAt = now, UpdatedAt = now },
                    new Order { Id = 9, CustomerId = 9, PaymentStatus = Constants.PaymentStatus.Pending, CreatedAt = now, UpdatedAt = now },
                    new Order { Id = 10, CustomerId = 10, PaymentStatus = Constants.PaymentStatus.Paid, CreatedAt = now, UpdatedAt = now }
                );
        }
    }
}
