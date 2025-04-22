using DAL.Entities.Pet;

namespace DAL.Repositories.Interfaces.Pet
{
    public interface ICatRepository
    {
        int CreateCat(Cat entity);
        int UpdateCat(Cat entity);
        int DeleteCat(int id);
        IQueryable<Cat> GetAllCats();
    }
}
