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

        public void Seeding(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            modelBuilder.Entity<Cat>().HasData(
                    new Cat { Id = 1, Name = "Milo", Age = "2", CategoryId = 1, Image = "milo.jpg", Description = "Playful Persian kitten", IsSold = false, CreatedAt = now, UpdatedAt = now },
                    new Cat { Id = 2, Name = "Luna", Age = "1", CategoryId = 2, Image = "luna.jpg", Description = "Elegant Siamese cat", IsSold = false, CreatedAt = now, UpdatedAt = now },
                    new Cat { Id = 3, Name = "Leo", Age = "3", CategoryId = 3, Image = "leo.jpg", Description = "Big and friendly Maine Coon", IsSold = true, CreatedAt = now, UpdatedAt = now },
                    new Cat { Id = 4, Name = "Zara", Age = "1", CategoryId = 4, Image = "zara.jpg", Description = "Energetic Bengal cat", IsSold = false, CreatedAt = now, UpdatedAt = now },
                    new Cat { Id = 5, Name = "Coco", Age = "4", CategoryId = 5, Image = "coco.jpg", Description = "Relaxed Ragdoll", IsSold = true, CreatedAt = now, UpdatedAt = now },
                    new Cat { Id = 6, Name = "Tom", Age = "2", CategoryId = 6, Image = "tom.jpg", Description = "Plush British Shorthair", IsSold = false, CreatedAt = now, UpdatedAt = now },
                    new Cat { Id = 7, Name = "Mimi", Age = "1", CategoryId = 7, Image = "mimi.jpg", Description = "Folded-ear cutie", IsSold = true, CreatedAt = now, UpdatedAt = now },
                    new Cat { Id = 8, Name = "Nala", Age = "2", CategoryId = 8, Image = "nala.jpg", Description = "Hairless Sphynx", IsSold = false, CreatedAt = now, UpdatedAt = now },
                    new Cat { Id = 9, Name = "Simba", Age = "3", CategoryId = 9, Image = "simba.jpg", Description = "Wild-looking Abyssinian", IsSold = false, CreatedAt = now, UpdatedAt = now },
                    new Cat { Id = 10, Name = "Oreo", Age = "5", CategoryId = 10, Image = "oreo.jpg", Description = "Big Norwegian climber", IsSold = true, CreatedAt = now, UpdatedAt = now }
                );
        }
    }
}
