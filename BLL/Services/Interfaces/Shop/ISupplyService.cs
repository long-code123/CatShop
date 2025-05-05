using DAL.Entities.Shop;

namespace BLL.Services.Interfaces.Shop
{
    public interface ISupplyService
    {
        void CreateSupply(Supply entity);
        void UpdateSupply(Supply entity);
        void DeleteSupply(int id);
        ICollection<Supply> GetAllSupplies();
    }
}
