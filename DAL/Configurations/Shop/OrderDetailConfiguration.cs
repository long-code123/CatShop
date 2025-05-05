using DAL.Entities.Shop;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.Shop
{
    public class OrderDetailConfiguration : IEntityConfiguration
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails").HasKey(orderDetail => orderDetail.Id);

                entity.Property(orderDetail => orderDetail.Id).UseIdentityColumn(1, 1);

                entity.HasOne(orderDetail => orderDetail.Order)
                    .WithMany(order => order.OrderDetails)
                    .HasForeignKey(orderDetail => orderDetail.OrderId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(orderDetail => orderDetail.Supply)
                    .WithMany(supply => supply.OrderDetails)
                    .HasForeignKey(orderDetail => orderDetail.SupplyId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }

        public void Seeding(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            modelBuilder.Entity<OrderDetail>().HasData(
                    new OrderDetail { Id = 1, OrderId = 1, SupplyId = 1, Quantity = 2, CreatedAt = now, UpdatedAt = now },
                    new OrderDetail { Id = 2, OrderId = 2, SupplyId = 3, Quantity = 1, CreatedAt = now, UpdatedAt = now },
                    new OrderDetail { Id = 3, OrderId = 3, SupplyId = 2, Quantity = 1, CreatedAt = now, UpdatedAt = now },
                    new OrderDetail { Id = 4, OrderId = 4, SupplyId = 4, Quantity = 1, CreatedAt = now, UpdatedAt = now },
                    new OrderDetail { Id = 5, OrderId = 5, SupplyId = 5, Quantity = 2, CreatedAt = now, UpdatedAt = now },
                    new OrderDetail { Id = 6, OrderId = 6, SupplyId = 6, Quantity = 3, CreatedAt = now, UpdatedAt = now },
                    new OrderDetail { Id = 7, OrderId = 7, SupplyId = 7, Quantity = 1, CreatedAt = now, UpdatedAt = now },
                    new OrderDetail { Id = 8, OrderId = 8, SupplyId = 8, Quantity = 2, CreatedAt = now, UpdatedAt = now },
                    new OrderDetail { Id = 9, OrderId = 9, SupplyId = 9, Quantity = 1, CreatedAt = now, UpdatedAt = now },
                    new OrderDetail { Id = 10, OrderId = 10, SupplyId = 10, Quantity = 2, CreatedAt = now, UpdatedAt = now }
                );
        }
    }
}
