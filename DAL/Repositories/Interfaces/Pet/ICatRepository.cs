using DAL.Entities.Pet;

namespace DAL.Repositories.Interfaces.Pet
{
    internal interface ICatRepository
    {
        int CreateCat(Cat entity);
        int UpdateCat(Cat entity, int id);
        int DeleteCat(int id);
        IQueryable<Cat> GetAllCats();
    }
}
