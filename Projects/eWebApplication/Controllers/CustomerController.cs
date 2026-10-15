using DataLayer.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace eShopWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private eShopWebDB _dbContext;

         
        public CustomerController(eShopWebDB dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpGet("all")]
        public List<Customer> GetAllCustomer()
        {
            var allcustomers =  _dbContext.Customers.ToList();
            return allcustomers;
        }



        [HttpGet("id")]
        public Customer GetCustomerById(int id)
        {            
            var customer =  _dbContext.Customers.FirstOrDefault(a=>a.CustomerId == id);
            return customer;
        }



        [HttpPost("create")]
        public void CreateCustomer(Customer model)
        {
            _dbContext.Customers.Add(model);
            var result = _dbContext.SaveChanges();
        }


    }
}
