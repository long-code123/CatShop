using DAL.Entities.Pet;
using DAL.Repositories.Interfaces.Pet;

namespace DAL.Repositories.Implementations.Pet
{
    public class IsLoveRepository : IIsLoveRepository
    {
        private readonly DataContext dataContext;

        public IsLoveRepository() { }

        public IsLoveRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int CreateIsLove(IsLove entity)
        {
            dataContext.Add(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int UpdateIsLove(IsLove entity)
        {
            dataContext.Update(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int DeleteIsLove(int id)
        {
            IsLove isLove = dataContext.IsLoves.Where(isLove => isLove.Id == id).FirstOrDefault();
            dataContext.IsLoves.Remove(isLove);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public IQueryable<IsLove> GetAllIsLoveCats()
        {
            IQueryable<IsLove> catIsLoves = dataContext.IsLoves;

            return catIsLoves;
        }
    }
}
