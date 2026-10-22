using DataLayer.DataModel;
using eShopWebApplication.Models;
using eShopWebApplication.Services.IServiceInterface;

namespace eShopWebApplication.Services
{
    public class ProductService : IProductService
    {
        private eShopWebDB _dbContext;
        public ProductService( eShopWebDB dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductModel> GetAllProducts()
        {
            var prodcuts = _dbContext.Products.ToList();
            List<ProductModel> productModelList = new List<ProductModel>();

            foreach(var item  in prodcuts)
            {
                var model = new ProductModel();

                model.ProductId = item.ProductId;
                model.ProductName = item.ProductName;
                model.CategoryId = item.CategoryId;
                model.StockQuantity = item.StockQuantity;
                model.Price = item.Price;
                model.Description = item.Description;

                productModelList.Add(model);
            }

            return productModelList;
        }

        public ProductModel GetById(int productId)
        {
            return null;
        }

        public bool CreateProduct(ProductModel model)
        {
            return true;
        }

    }
}
