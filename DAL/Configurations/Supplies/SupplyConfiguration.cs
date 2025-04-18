using DAL.Entities.Supplies;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.Supplies
{
    public class SupplyConfiguration : IEntityConfiguration
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supply>(entity =>
            {
                entity.ToTable("Supplies").HasKey(supply =>  supply.Id);

                entity.Property(supply => supply.Id).UseIdentityColumn(1, 1);
            });
        }
    }
}
