using BLL.Services.Interfaces.Pet;
using DAL.Entities.Pet;
using DAL.Repositories.Interfaces.Pet;

namespace BLL.Services.Implementations.Pet
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public CategoryService() { }

        public void CreateCategory(Category entity)
        {
            categoryRepository.CreateCategory(entity);
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
        }

        public void UpdateCategory(Category entity)
        {
            categoryRepository.UpdateCategory(entity);
        }

        public ICollection<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories().ToList();

        }
    }
}
