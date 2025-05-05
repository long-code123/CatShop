using DAL.Entities.Shop;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.Shop
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

        public void Seeding(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            modelBuilder.Entity<Supply>().HasData(
                    new Supply { Id = 1, TypeSupply = Constants.TypeSupply.Food, Name = "Cat Food", Quantity = 100, Description = "Premium dry cat food", Price = 12.5, Image = "cat_food.jpg", CreatedAt = now, UpdatedAt = now },
                    new Supply { Id = 2, TypeSupply = Constants.TypeSupply.Accessory, Name = "Litter Box", Quantity = 50, Description = "Easy clean litter box", Price = 20.0, Image = "litter_box.jpg", CreatedAt = now, UpdatedAt = now },
                    new Supply { Id = 3, TypeSupply = Constants.TypeSupply.Toy, Name = "Cat Toys", Quantity = 200, Description = "Pack of 10 toys", Price = 15.0, Image = "cat_toys.jpg", CreatedAt = now, UpdatedAt = now },
                    new Supply { Id = 4, TypeSupply = Constants.TypeSupply.Accessory, Name = "Cat Tree", Quantity = 30, Description = "Multi-level climbing tree", Price = 70.0, Image = "cat_tree.jpg", CreatedAt = now, UpdatedAt = now },
                    new Supply { Id = 5, TypeSupply = Constants.TypeSupply.Medicine, Name = "Cat Shampoo", Quantity = 40, Description = "Gentle cat shampoo", Price = 8.5, Image = "cat_shampoo.jpg", CreatedAt = now, UpdatedAt = now },
                    new Supply { Id = 6, TypeSupply = Constants.TypeSupply.Accessory, Name = "Food Bowl", Quantity = 100, Description = "Double bowl set", Price = 10.0, Image = "food_bowl.jpg", CreatedAt = now, UpdatedAt = now },
                    new Supply { Id = 7, TypeSupply = Constants.TypeSupply.Toy, Name = "Scratching Post", Quantity = 60, Description = "Durable scratching post", Price = 25.0, Image = "scratch_post.jpg", CreatedAt = now, UpdatedAt = now },
                    new Supply { Id = 8, TypeSupply = Constants.TypeSupply.Accessory, Name = "Carrier Box", Quantity = 30, Description = "Portable carrier", Price = 35.0, Image = "carrier_box.jpg", CreatedAt = now, UpdatedAt = now },
                    new Supply { Id = 9, TypeSupply = Constants.TypeSupply.Accessory, Name = "Cat Brush", Quantity = 80, Description = "Soft bristle brush", Price = 7.5, Image = "cat_brush.jpg", CreatedAt = now, UpdatedAt = now },
                    new Supply { Id = 10, TypeSupply = Constants.TypeSupply.Food, Name = "Cat Treats", Quantity = 120, Description = "Healthy cat snacks", Price = 5.0, Image = "cat_treats.jpg", CreatedAt = now, UpdatedAt = now }
                );
        }
    }
}
