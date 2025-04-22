using DAL.Entities.Human;
using DAL.Repositories.Interfaces.Human;

namespace DAL.Repositories.Implementations.Human
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public CustomerRepository() { }

        public int CreateCustomer(Customer entity)
        {
            dataContext.Add(entity);
            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public int DeleteCustomer(int id)
        {
            Customer customer = dataContext.Customers.Where(cus => cus.Id == id).FirstOrDefault();
            dataContext.Customers.Remove(customer);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            IQueryable<Customer> customers = dataContext.Customers;
            return customers;
        }

        public int UpdateCustomer(Customer entity)
        {
            dataContext.Update(entity);

            int number_rows = dataContext.SaveChanges();
            return number_rows;
        }

        public Customer GetCustomerByEmail(string email)
        {
            var customer = dataContext.Customers.Where(cus => cus.Email == email).FirstOrDefault();
            return customer;
        }
    }
}
