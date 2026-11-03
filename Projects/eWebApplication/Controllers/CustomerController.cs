using DataLayer.DataModel;
using eShopWebApplication.Common;
using eShopWebApplication.Models;
using eShopWebApplication.Services;
using eShopWebApplication.Services.IServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult GetAllCustomer()
        {
            List<Customer> result = new List<Customer>();
            try
            {
                result = _customerService.GetAllCustomers();
                return Ok(result.apiSuccessResponse("Customer Fetch sucessully"));
            }
            catch (Exception ex)
            {
                result.apiErrorResponse("Error occured while fetching the customer", ex.ToString());
                return BadRequest(result);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            List<Customer> result = new List<Customer>();
            try
            {
                var data = _customerService.GetById(id);
                if (data is not null)
                {
                    return Ok(data.apiSuccessResponse("Customer Found."));
                }
                else
                {
                    return BadRequest(data.apiErrorResponse($"Customer with Id {id} not found", ""));
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        [HttpPost("create")]
        public void CreateCustomer(CustomerModel model)
        {
            _customerService.CreateCustomer(model);
        }

    }
}
