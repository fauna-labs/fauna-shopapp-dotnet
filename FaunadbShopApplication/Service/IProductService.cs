using FaunadbShopApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<bool> AddProduct(ProductDto product);
        Task<bool> AddCategory(string name);
        Task<IEnumerable<Product>> GetRecentProducts();
        Task<IEnumerable<Product>> GetProductsSortedByName();
        Task<IEnumerable<Product>> GetProductsByCategory(string categoryId);
    }
}
