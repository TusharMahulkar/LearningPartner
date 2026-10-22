using eShopWebApplication.Models;

namespace eShopWebApplication.Services.IServiceInterface
{
    public interface IProductService
    {
        public List<ProductModel> GetAllProducts();

        public ProductModel GetById(int productId);

        public bool CreateProduct(ProductModel model);
    }
}
