using DAL.Entities.Shop;
using DAL.Repositories.Interfaces.Shop;

namespace DAL.Repositories.Implementations.Shop
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly DataContext dataContext;

        public SupplyRepository() { }

        public SupplyRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int CreateSupply(Supply entity)
        {
            dataContext.Add(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int UpdateSupply(Supply entity)
        {
            dataContext.Update(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int DeleteSupply(int id)
        {
            Supply supply = dataContext.Supplies.Where(supply => supply.Id == id).FirstOrDefault();
            dataContext.Supplies.Remove(supply);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public IQueryable<Supply> GetAllSupplies()
        {
            IQueryable<Supply> supplies = dataContext.Supplies;

            return supplies;
        }
    }
}
