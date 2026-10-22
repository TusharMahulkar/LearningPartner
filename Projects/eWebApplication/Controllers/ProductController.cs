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

        [HttpGet]
        public List<ProductModel> GetAllProducts()
        {
             return _productService.GetAllProducts();
        }

        [HttpGet("productId")]
        public void GetById(int productId)
        { 
                _productService.GetById(productId);
        }
    }
}
