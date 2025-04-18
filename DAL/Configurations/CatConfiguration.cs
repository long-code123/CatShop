using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations
{
    public static class CatConfiguration
    {
        public static void OnCatModelCreating(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasOne(cat => cat.Category).WithMany().HasForeignKey(cat => cat.CategoryId);
        }
    }
}
