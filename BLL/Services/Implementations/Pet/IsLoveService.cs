using BLL.Services.Interfaces.Pet;
using DAL.Entities.Pet;

namespace BLL.Services.Implementations.Pet
{
    public class IsLoveService : IIsLoveService
    {
        private readonly IIsLoveService isLoveService;

        public IsLoveService(IIsLoveService isLoveService) 
        {
            this.isLoveService = isLoveService;
        }

        public IsLoveService() { }

        public void CreateIsLove(IsLove entity)
        {
            isLoveService.CreateIsLove(entity);
        }

        public void DeleteIsLove(int id)
        {
            isLoveService.DeleteIsLove(id);
        }

        public void UpdateIsLove(IsLove entity)
        {
            isLoveService.UpdateIsLove(entity);
        }

        public ICollection<IsLove> GetAllIsLoves()
        {
            return isLoveService.GetAllIsLoves();
        }
    }
}
