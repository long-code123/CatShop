using DAL.Entities.Pet;
using DAL.Repositories.Interfaces.Pet;

namespace DAL.Repositories.Implementations.Pet
{
    public class CatService : ICatRepository
    {
        private readonly DataContext dataContext;
        
        public CatService() { }

        public CatService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int CreateCat(Cat entity)
        {
            dataContext.Add(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int UpdateCat(Cat entity, int id)
        {
            Cat cat = dataContext.Cats.Where(cat => cat.Id == id).FirstOrDefault();
            cat.Name = entity.Name;
            cat.Age = entity.Age;
            cat.Category = entity.Category;
            cat.Image = entity.Image;
            cat.Description = entity.Description;
            cat.IsSold = entity.IsSold;

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int DeleteCat(int id)
        {
            Cat cat = dataContext.Cats.Where(cat => cat.Id == id).FirstOrDefault();
            dataContext.Cats.Remove(cat);
            
            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public IQueryable<Cat> GetAllCats()
        {
            IQueryable<Cat> cats = dataContext.Cats.Select(cat => cat);

            return cats;
        }
    }
}
