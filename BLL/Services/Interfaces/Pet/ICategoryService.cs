using DAL.Entities.Pet;

namespace BLL.Services.Interfaces.Pet
{
    public interface ICategoryService
    {
        void CreateCategory(Category entity);
        void UpdateCategory(Category entity);
        void DeleteCategory(int id);
        ICollection<Category> GetAllCategories();
    }
}
