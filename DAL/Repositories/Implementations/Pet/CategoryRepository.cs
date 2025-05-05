using DAL.Entities.Pet;
using DAL.Repositories.Interfaces.Pet;

namespace DAL.Repositories.Implementations.Pet
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext dataContext;

        public CategoryRepository() { }

        public CategoryRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int CreateCategory(Category entity)
        {
            dataContext.Add(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int UpdateCategory(Category entity)
        {
            dataContext.Update(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int DeleteCategory(int id)
        {
            Category category = dataContext.Categories.Where(cate => cate.Id == id).FirstOrDefault();
            dataContext.Categories.Remove(category);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public IQueryable<Category> GetAllCategories()
        {
            IQueryable<Category> categories = dataContext.Categories;

            return categories;
        }
    }
}
