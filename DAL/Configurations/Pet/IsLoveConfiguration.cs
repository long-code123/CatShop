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

        public void Seeding(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            modelBuilder.Entity<IsLove>().HasData(
                    new IsLove { Id = 1, CatId = 1, CustomerId = 1, CreatedAt = now, UpdatedAt = now },
                    new IsLove { Id = 2, CatId = 2, CustomerId = 2, CreatedAt = now, UpdatedAt = now },
                    new IsLove { Id = 3, CatId = 3, CustomerId = 3, CreatedAt = now, UpdatedAt = now },
                    new IsLove { Id = 4, CatId = 4, CustomerId = 4, CreatedAt = now, UpdatedAt = now },
                    new IsLove { Id = 5, CatId = 5, CustomerId = 5, CreatedAt = now, UpdatedAt = now },
                    new IsLove { Id = 6, CatId = 6, CustomerId = 6, CreatedAt = now, UpdatedAt = now },
                    new IsLove { Id = 7, CatId = 7, CustomerId = 7, CreatedAt = now, UpdatedAt = now },
                    new IsLove { Id = 8, CatId = 8, CustomerId = 8, CreatedAt = now, UpdatedAt = now },
                    new IsLove { Id = 9, CatId = 9, CustomerId = 9, CreatedAt = now, UpdatedAt = now },
                    new IsLove { Id = 10, CatId = 10, CustomerId = 10, CreatedAt = now, UpdatedAt = now }
                );
        }
    }
}
