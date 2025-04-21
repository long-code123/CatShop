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

        public void Seeding(ModelBuilder modelBuilder) 
        {
            var now = DateTime.Now;
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Persian Cat", Description = "Long-haired, calm and gentle.", CreatedAt = now, UpdatedAt = now },
                new Category { Id = 2, CategoryName = "Siamese Cat", Description = "Elegant with striking blue eyes and short coat.", CreatedAt = now, UpdatedAt = now },
                new Category { Id = 3, CategoryName = "Maine Coon", Description = "One of the largest domestic cats, fluffy and friendly.", CreatedAt = now, UpdatedAt = now },
                new Category { Id = 4, CategoryName = "Bengal Cat", Description = "Wild-looking coat, very active and playful.", CreatedAt = now, UpdatedAt = now },
                new Category { Id = 5, CategoryName = "Ragdoll", Description = "Blue-eyed and docile, loves to be cuddled.", CreatedAt = now, UpdatedAt = now },
                new Category { Id = 6, CategoryName = "British Shorthair", Description = "Stocky with a plush coat, very calm.", CreatedAt = now, UpdatedAt = now },
                new Category { Id = 7, CategoryName = "Scottish Fold", Description = "Known for its cute folded ears.", CreatedAt = now, UpdatedAt = now },
                new Category { Id = 8, CategoryName = "Sphynx Cat", Description = "Hairless breed, very affectionate and curious.", CreatedAt = now, UpdatedAt = now },
                new Category { Id = 9, CategoryName = "Abyssinian", Description = "Short coat with a wild, ticked fur pattern.", CreatedAt = now, UpdatedAt = now },
                new Category { Id = 10, CategoryName = "Norwegian Forest Cat", Description = "Thick coat, strong and agile climber.", CreatedAt = now, UpdatedAt = now }
                );
        }
    }
}
