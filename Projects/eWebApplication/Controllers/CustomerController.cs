using DataLayer.DataModel;
using eShopWebApplication.Models;
using eShopWebApplication.Services;
using eShopWebApplication.Services.IServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace eShopWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService CustomerService)
        {
            _customerService = CustomerService;
        }

        [HttpGet("all")]
        public List<Customer> GetAllCustomer()
        {
            var data = _customerService.GetAllCustomers();
            return data;
        }


        [HttpGet("id")]
        public Customer GetCustomerById(int id)
        {
            var customer = _customerService.GetById(id);             
            return customer;
        }

        [HttpPost("create")]
        public void CreateCustomer(CustomerModel model)
        {
            _customerService.CreateCustomer(model);             
        }

    }
}
