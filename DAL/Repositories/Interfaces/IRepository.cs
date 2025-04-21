namespace DAL.Repositories.Interfaces
{
    internal interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity, int id);
        void Delete(int id);
        List<T> GetAll();
    }
}
