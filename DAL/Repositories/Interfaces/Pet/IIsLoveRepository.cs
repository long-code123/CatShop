using DAL.Entities.Pet;

namespace DAL.Repositories.Interfaces.Pet
{
    public interface IIsLoveRepository
    {
        int CreateIsLove(IsLove entity);
        int UpdateIsLove(IsLove entity);
        int DeleteIsLove(int id);
        IQueryable<IsLove> GetAllIsLoveCats();
    }
}
