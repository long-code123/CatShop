using DAL.Entities.Pet;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.Pet
{
    public class IsLoveConfiguration : IEntityConfiguration
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IsLove>(entity =>
            {
                entity.ToTable("IsLoves").HasKey(isLove =>  isLove.Id);

                entity.Property(isLove => isLove.Id).UseIdentityColumn(1, 1);

                entity.HasOne(isLove => isLove.Customer)
                    .WithMany(customer => customer.IsLoves)
                    .HasForeignKey(isLove => isLove.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(isLove => isLove.Cat)
                    .WithMany(cat => cat.IsLoves)
                    .HasForeignKey(isLove => isLove.CatId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
