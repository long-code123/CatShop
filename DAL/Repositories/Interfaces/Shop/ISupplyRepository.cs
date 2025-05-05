using DAL.Entities.Shop;

namespace DAL.Repositories.Interfaces.Shop
{
    public interface ISupplyRepository
    {
        int CreateSupply(Supply entity);
        int UpdateSupply(Supply entity);
        int DeleteSupply(int id);
        IQueryable<Supply> GetAllSupplies();
    }
}
