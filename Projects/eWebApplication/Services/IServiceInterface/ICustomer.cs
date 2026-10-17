using DataLayer.DataModel;
using eShopWebApplication.Models;

namespace eShopWebApplication.Services.IServiceInterface
{
    public interface ICustomerService
    {
        public List<Customer> GetAllCustomers();

        public Customer GetById(int id);

        public void CreateCustomer(CustomerModel model);

    }
}
