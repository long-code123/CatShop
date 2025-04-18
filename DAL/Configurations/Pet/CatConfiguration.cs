using DAL.Entities.Pet;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.Pet
{
    public class CatConfiguration : IEntityConfiguration
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>(entity =>
            {
                entity.ToTable("Cats").HasKey(cat => cat.Id);

                entity.Property(cat => cat.Id).UseIdentityColumn(1, 1);

                entity.HasOne(cat => cat.Category)
                    .WithMany(category => category.Cats)
                    .HasForeignKey(cat => cat.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
