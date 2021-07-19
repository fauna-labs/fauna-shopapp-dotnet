using FaunadbShopApplication.Dto;
using FaunadbShopApplication.Helpers;
using FaunadbShopApplication.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get all product categories
        /// </summary>
        //[Authorize]
        [HttpGet("GetAllCategories")]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _productService.GetCategories();
        }

        /// <summary>
        /// Get recent products
        /// </summary>
        //[Authorize]
        [HttpGet("GetRecentProducts")]
        public async Task<IEnumerable<Product>> GetRecentProducts()
        {
            return await _productService.GetRecentProducts();
        }

        /// <summary>
        /// Get products, sorted by name and price
        /// </summary>
        //[Authorize]
        [HttpGet("GetProductsSortedByName")]
        public async Task<IEnumerable<Product>> GetProductsSortedByName()
        {
            return await _productService.GetProductsSortedByName();
        }

        /// <summary>
        /// Get products by category
        /// </summary>
        /// <param name="categoryId"></param>
        //[Authorize]
        [HttpGet("GetProductsByCategory")]
        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryId)
        {
            return await _productService.GetProductsByCategory(categoryId);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        [HttpPut("AddProduct")]
        public async Task<bool> AddProduct(ProductDto product)
        {
            return await _productService.AddProduct(product);
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param name="categoryName"></param>
        [HttpPut("AddNewCategory")]
        public async Task<bool> AddNewCategory(string categoryName)
        {
            return await _productService.AddCategory(categoryName);
        }

    }
}
