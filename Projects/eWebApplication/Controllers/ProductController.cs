using eShopWebApplication.Common;
using eShopWebApplication.Models;
using eShopWebApplication.Services.IServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace eShopWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpPost("Create")]
        public List<ProductModel> CreateProduct(ProductModel model)
        {             
            return null;
        }

        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
             var result = _productService.GetAllProducts();
            return Ok(result.apiSuccessResponse("Prouct data fetch successufully"));
        }


        [HttpGet("productId")]
        public void GetById(int productId)
        { 
            _productService.GetById(productId);
        }


    }
}
