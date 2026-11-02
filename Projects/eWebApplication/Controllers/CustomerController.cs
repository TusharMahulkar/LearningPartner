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
        public ApiResponse<Customer> GetAllCustomer()
        {
            ApiResponse<Customer> apiResponse = new ApiResponse<Customer>();

            try
            {
                var data = _customerService.GetAllCustomers();
                apiResponse.IsSucess = true;
                apiResponse.Data.AddRange(data);
                apiResponse.Message = "Customer fetched successfully";
                apiResponse.statusCode = 200;
                apiResponse.totalRecords = data.Count();
            }
            catch (Exception ex)
            {
                apiResponse.IsSucess = false;
                apiResponse.Message = "Unable to fetch the customers data, please contact administrator";
                apiResponse.statusCode = 500;
            }

            return apiResponse;
        }


        [HttpGet("{id}")]
        public ApiResponse<CustomerModel> GetCustomerById(int id)
        {
            ApiResponse<CustomerModel> apiResponse = new ApiResponse<CustomerModel>();

            try
            {
                var data = _customerService.GetById(id);
                if (data is not null)
                {
                    apiResponse.Data.Add(data);
                    apiResponse.hasMoreData = false;
                    apiResponse.totalRecords = 1;
                    apiResponse.Message = "Customer Data read successfully.";
                    apiResponse.ErrorMessage = new List<string>();
                }
                else
                {                     
                    apiResponse.hasMoreData = false;
                    apiResponse.totalRecords = 0;
                    apiResponse.statusCode = 204;
                    apiResponse.Message = $"Customer with Id : {id} not found.";
                    apiResponse.ErrorMessage = new List<string>();
                }
            }
            catch (Exception ex)
            {
                apiResponse.hasMoreData = false;
                apiResponse.totalRecords = 0;
                apiResponse.Message = $"Exception occured while fetching the customer ID: {id} not found. {ex}";
                apiResponse.ErrorMessage = new List<string>();
            }
            return apiResponse;
        }



        [HttpPost("create")]
        public void CreateCustomer(CustomerModel model)
        {
            _customerService.CreateCustomer(model);
        }

    }
}
