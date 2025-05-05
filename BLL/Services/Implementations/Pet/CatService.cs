using BLL.Services.Interfaces.Pet;
using DAL.Entities.Pet;
using DAL.Repositories.Interfaces.Pet;

namespace BLL.Services.Implementations.Pet
{
    public class CatService : ICatService
    {
        private readonly ICatRepository catRepository;

        public CatService(ICatRepository catRepository)
        {
            this.catRepository = catRepository;
        }

        public CatService() { }

        public void CreateCat(Cat entity)
        {
            catRepository.CreateCat(entity);
        }

        public void DeleteCat(int id)
        {
            catRepository.DeleteCat(id);
        }

        public void UpdateCat(Cat entity)
        {
            catRepository.UpdateCat(entity);
        }

        public ICollection<Cat> GetAllCats()
        {
            return catRepository.GetAllCats().ToList();
            
        }
    }
}
