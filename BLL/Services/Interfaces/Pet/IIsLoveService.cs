using DAL.Entities.Pet;

namespace BLL.Services.Interfaces.Pet
{
    public interface IIsLoveService
    {
        void CreateIsLove(IsLove entity);
        void UpdateIsLove(IsLove entity);
        void DeleteIsLove(int id);
        ICollection<IsLove> GetAllIsLoves();
    }
}
