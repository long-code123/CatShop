using DAL.Entities.Pet;

namespace BLL.Services.Interfaces.Pet
{
    public interface ICatService
    {
        void CreateCat(Cat entity);
        void UpdateCat(Cat entity);
        void DeleteCat(int id);
        ICollection<Cat> GetAllCats();
    }
}
