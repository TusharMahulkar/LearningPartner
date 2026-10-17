using DataLayer.DataModel;
using eShopWebApplication.Models;
using eShopWebApplication.Services.IServiceInterface;

namespace eShopWebApplication.Services
{
    public class CustomerService : ICustomerService
    {
        private eShopWebDB _dbContext;

        public CustomerService(eShopWebDB dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = _dbContext.Customers.ToList();
            return customers;
        }

        public Customer GetById(int id)
        {
            var customers = _dbContext.Customers.FirstOrDefault(a => a.CustomerId == id);
            return customers;
        }

        public void CreateCustomer(CustomerModel model)
        {
            //Implement save logic
            var customers = _dbContext.Customers.FirstOrDefault(a => a.CustomerId == model.CustomerId);
            if (customers == null)
            {
                var newCustomer = new Customer();
                newCustomer.CustomerId = model.CustomerId;
                newCustomer.FirstName= model.FirstName;
                newCustomer.LastName= model.LastName;
                newCustomer.Email= model.Email;
                newCustomer.Phone= model.Phone;
                newCustomer.IsActive = true;

                _dbContext.Customers.Add(newCustomer);
                _dbContext.SaveChanges();

            }
        }
    }
}
