using DAL.Entities.Pet;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.Pet
{
    public class CategoryConfiguration : IEntityConfiguration
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories").HasKey(category => category.Id);

                entity.Property(category => category.Id).UseIdentityColumn(1, 1);

            });
        }
    }
}
