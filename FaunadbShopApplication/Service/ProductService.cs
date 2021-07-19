using FaunadbShopApplication.Dto;
using FaunadbShopApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Service
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddCategory(string name)
        {
            return await _repository.AddCategory(name);
        }

        public async Task<bool> AddProduct(ProductDto product)
        {
            return await _repository.AddProduct(product);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _repository.GetCategories();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryId)
        {
            return await _repository.GetProductsByCategory(categoryId);
        }

        public async Task<IEnumerable<Product>> GetProductsSortedByName()
        {
            return await _repository.GetProductsSortedByName();
        }

        public async Task<IEnumerable<Product>> GetRecentProducts()
        {
            return await _repository.GetRecentProducts();
        }
    }
}
