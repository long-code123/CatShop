using DAL.Entities.Human;
using DAL.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.Human
{
    public class CustomerConfiguration : IEntityConfiguration
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers").HasKey(customer => customer.Id);

                entity.Property(customer => customer.Id).UseIdentityColumn(1, 1);
            });
        }

        public void Seeding(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            modelBuilder.Entity<Customer>().HasData(
                    new Customer { Id = 1, Name = "Alice Nguyen", Phone = "0901234567", Address = "Hanoi", Email = "alice@example.com", Password = PasswordUtil.HashPassword("123456"), LoginType = Constants.LoginType.Google, CreatedAt = now, UpdatedAt = now },
                    new Customer { Id = 2, Name = "Bob Tran", Phone = "0912345678", Address = "Saigon", Email = "bob@example.com", Password = PasswordUtil.HashPassword("123456"), LoginType = Constants.LoginType.Google, CreatedAt = now, UpdatedAt = now },
                    new Customer { Id = 3, Name = "Charlie Le", Phone = "0923456789", Address = "Da Nang", Email = "charlie@example.com", Password = PasswordUtil.HashPassword("123456"), LoginType = Constants.LoginType.Password, CreatedAt = now, UpdatedAt = now },
                    new Customer { Id = 4, Name = "David Pham", Phone = "0934567890", Address = "Can Tho", Email = "david@example.com", Password = PasswordUtil.HashPassword("123456"), LoginType = Constants.LoginType.Google, CreatedAt = now, UpdatedAt = now },
                    new Customer { Id = 5, Name = "Evelyn Hoang", Phone = "0945678901", Address = "Hue", Email = "evelyn@example.com", Password = PasswordUtil.HashPassword("123456"), LoginType = Constants.LoginType.Password, CreatedAt = now, UpdatedAt = now },
                    new Customer { Id = 6, Name = "Frank Vo", Phone = "0956789012", Address = "Vung Tau", Email = "frank@example.com", Password = PasswordUtil.HashPassword("123456"), LoginType = Constants.LoginType.Google, CreatedAt = now, UpdatedAt = now },
                    new Customer { Id = 7, Name = "Grace Bui", Phone = "0967890123", Address = "Bien Hoa", Email = "grace@example.com", Password = PasswordUtil.HashPassword("123456"), LoginType = Constants.LoginType.Password, CreatedAt = now, UpdatedAt = now },
                    new Customer { Id = 8, Name = "Henry Do", Phone = "0978901234", Address = "Hai Phong", Email = "henry@example.com", Password = PasswordUtil.HashPassword("123456"), LoginType = Constants.LoginType.Password, CreatedAt = now, UpdatedAt = now },
                    new Customer { Id = 9, Name = "Isabella Dang", Phone = "0989012345", Address = "Nha Trang", Email = "isabella@example.com", Password = PasswordUtil.HashPassword("123456"), LoginType = Constants.LoginType.Password, CreatedAt = now, UpdatedAt = now },
                    new Customer { Id = 10, Name = "Jackie Lam", Phone = "0990123456", Address = "Quy Nhon", Email = "jackie@example.com", Password = PasswordUtil.HashPassword("123456"), LoginType = Constants.LoginType.Password, CreatedAt = now, UpdatedAt = now }
                );
        }
    }
}
