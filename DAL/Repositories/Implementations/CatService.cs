using DAL.Entities.Pet;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations
{
    internal class CatService : ICatRepository
    {
        public void Create(Cat entity)
        {
            using var dataContext = new DataContext();
            Cat cat = new()
            {
                Name = entity.Name,
                Age = entity.Age,
                Category = entity.Category,
                Image = entity.Image,
                Description = entity.Description,
                IsSold = entity.IsSold
            };

            dataContext.Add(cat);

            int number_rows = dataContext.SaveChanges();
            Console.WriteLine($"{number_rows} Cat has been created");
            throw new NotImplementedException();
        }

        public void Update(Cat entity, int id)
        {
            using var dataContext = new DataContext();
            Cat cat = dataContext.Cats.Where(cat => cat.Id == id).FirstOrDefault();
            if(cat != null)
            {
                cat.Name = entity.Name;
                cat.Age = entity.Age;
                cat.Category = entity.Category;
                cat.Image = entity.Image;
                cat.Description = entity.Description;
                cat.IsSold = entity.IsSold;

                int number_rows = dataContext.SaveChanges();
                Console.WriteLine($"{number_rows} Cat has been updated");
            }
            else
            {
                Console.WriteLine("Do not have id match");
            }
                throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using var dataContext = new DataContext();
            Cat cat = dataContext.Cats.Where(cat => cat.Id == id).FirstOrDefault();
            if (cat != null)
            {
                dataContext.Cats.Remove(cat);
                int number_rows = dataContext.SaveChanges();
                Console.WriteLine($"{number_rows} Cat has been removed");
            }
            else
            {
                Console.WriteLine("Do not have id match");
            }
            throw new NotImplementedException();
        }

        public List<Cat> GetAll()
        {
            using var dataContext = new DataContext();
            List<Cat> cats = dataContext.Cats.Select(cat => cat).ToList();
            throw new NotImplementedException();
        }
    }
}
