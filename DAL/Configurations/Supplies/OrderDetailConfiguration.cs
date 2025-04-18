using DAL.Entities.Supplies;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.Supplies
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
    }
}
