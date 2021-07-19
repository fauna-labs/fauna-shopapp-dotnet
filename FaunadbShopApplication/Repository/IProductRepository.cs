using FaunadbShopApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<bool> AddCategory(string name);
        Task<bool> AddProduct(ProductDto product);
        Task<IEnumerable<Product>> GetRecentProducts();
        Task<IEnumerable<Product>> GetProductsSortedByName();
        Task<IEnumerable<Product>> GetProductsByCategory(string categoryId);
    }
}
