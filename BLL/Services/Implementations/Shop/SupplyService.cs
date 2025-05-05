using BLL.Services.Interfaces.Shop;
using DAL.Entities.Shop;

namespace BLL.Services.Implementations.Shop
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyService supplyService;

        public SupplyService(ISupplyService supplyService)
        {
            this.supplyService = supplyService;
        }

        public SupplyService() { }

        public void CreateSupply(Supply entity)
        {
            supplyService.CreateSupply(entity);
        }

        public void DeleteSupply(int id)
        {
            supplyService.DeleteSupply(id);
        }
        public void UpdateSupply(Supply entity)
        {
            supplyService.UpdateSupply(entity);
        }

        public ICollection<Supply> GetAllSupplies()
        {
            return supplyService.GetAllSupplies();
        }
    }
}
