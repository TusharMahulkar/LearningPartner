using DataLayer.DataModel;
using eShopWebApplication.Models;
using eShopWebApplication.Services.IServiceInterface;
using SQLDataLayer.Repository;

namespace eShopWebApplication.Services
{
    public class ProductService : IProductService
    {
        IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductModel> GetAllProducts()
        {
            var prodcuts = _productRepository.GetAll();
            List<ProductModel> productModelList = new List<ProductModel>();

            foreach (var item in prodcuts)
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
            var product = _productRepository.GetById(productId);
            var model = new ProductModel();

            model.ProductId = product.ProductId;
            model.ProductName = product.ProductName;
            model.CategoryId = product.CategoryId;
            model.StockQuantity = product.StockQuantity;
            model.Price = product.Price;
            model.Description = product.Description;

            return model;

        }

        public bool CreateProduct(ProductModel model)
        {
            var product = new Product();

            product.ProductId = model.ProductId;
            product.ProductName = model.ProductName;
            product.CategoryId = model.CategoryId;
            product.StockQuantity = model.StockQuantity;
            product.Price = model.Price;
            product.Description = model.Description;

             return _productRepository.AddItem(product);
        }

    }
}
