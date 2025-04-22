using DAL.Entities.Human;

namespace DAL.Repositories.Interfaces.Human
{
    public interface ICustomerRepository
    {
        int CreateCustomer(Customer entity);
        int UpdateCustomer(Customer entity);
        int DeleteCustomer(int id);
        IQueryable<Customer> GetAllCustomers();
        Customer GetCustomerByEmail(string email);
    }
}
