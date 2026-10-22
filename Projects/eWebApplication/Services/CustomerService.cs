using DataLayer.DataModel;
using eShopWebApplication.Models;
using eShopWebApplication.Services.IServiceInterface;
using SQLDataLayer.Repository;
using System.Reflection.Metadata.Ecma335;

namespace eShopWebApplication.Services
{
    public class CustomerService : ICustomerService
    {
        IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();                          
        }

        public void CreateCustomer(CustomerModel model)
        {
            //Implement save logic
            Customer customer = new Customer();
            customer.CustomerId = model.CustomerId;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Email = model.Email;
            customer.CreatedBy = 1;
            customer.CreatedDate = System.DateTime.Now; 

            _customerRepository.AddItem(customer);
        }

        public CustomerModel GetById(int id)
        {
            var customerData = _customerRepository.GetById(id);

            if(customerData is not null)
            {
                CustomerModel model = new CustomerModel();

                model.CustomerId= customerData.CustomerId;
                model.FirstName = customerData.FirstName;
                model.LastName = customerData.LastName;
                model.Email = customerData.Email;

                return model;
            }

            return new CustomerModel();
        }

    }
}
