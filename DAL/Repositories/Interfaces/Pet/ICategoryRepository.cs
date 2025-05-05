using DAL.Entities.Pet;

namespace DAL.Repositories.Interfaces.Pet
{
    public interface ICategoryRepository
    {
        int CreateCategory(Category entity);
        int UpdateCategory(Category entity);
        int DeleteCategory(int id);
        IQueryable<Category> GetAllCategories();
    }
}
