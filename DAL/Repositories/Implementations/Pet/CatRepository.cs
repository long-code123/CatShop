using DAL.Entities.Pet;
using DAL.Repositories.Interfaces.Pet;

namespace DAL.Repositories.Implementations.Pet
{
    public class CatRepository : ICatRepository
    {
        private readonly DataContext dataContext;
        
        public CatRepository() { }

        public CatRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int CreateCat(Cat entity)
        {
            dataContext.Add(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int UpdateCat(Cat entity)
        {
            //dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.Update(entity);

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
            IQueryable<Cat> cats = dataContext.Cats;

            return cats;
        }
    }
}
