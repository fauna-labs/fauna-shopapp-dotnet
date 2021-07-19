using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaunadbShopApplication.Dto;
using FaunadbShopApplication.Repository;
using NUnit.Framework;
namespace FaunadbShopApplication.Test
{
    public class RepositoryTest: TestBase
    {
        private const string userPhoneNumber = "15417543013";
        private  IUserRepository userRepository;
        private IProductRepository productRepository;
        [SetUp]
        public void Setup()
        {
            userRepository  = new UserRepository(Configuration);
            productRepository = new ProductRepository(Configuration);
        }
        
        [Test]
        public async Task GetUserByPhoneTest()
        {
            var user = await userRepository.GetUserByPhone(userPhoneNumber);
            Assert.IsNotNull(user, "Can't find user in database");
        }

        [Test]
        public async Task AddUserTest()
        {
            User user = new User()
            {
                FirstName = "Ron",
                LastName = "Howard",
                BirthDate = new DateTime(1980, 1, 10),
                Password = "passw1",
                PhoneNumber = "15417543014",
                Address = "Some street 2",
                UserType = UserRoles.CUSTOMER
            };
            var result = await userRepository.AddUser(user);
            Assert.IsTrue(result, "New user hasn't been created");
        }

        [Test]
        public async Task GetAllCategoriesTest()
        {
            var categories = await productRepository.GetCategories();
            Assert.IsTrue(categories.Any(), "Can't get any category from database");
        }

        [Test]
        public async Task AddNewProductTest()
        {
            ProductDto product = new ProductDto()
            {
                Name = "Herring",
                Price = 8.22,
                Weight =1,
                CategoryId = (await productRepository.GetCategories()).First().Id,
                Quantity = 1
            };
            var result =  await productRepository.AddProduct(product);
            Assert.IsTrue(result, "Can't add new product");
        }

        [Test]
        public async Task GetRecentProducts()
        {
            var result = await productRepository.GetRecentProducts();
            Assert.IsTrue(result.Any(), "Can't get any product from database");
        }

        [Test]
        public async Task GetSordedByNamePriceProducts()
        {
            var result = await productRepository.GetProductsSortedByName(); ;
            Assert.IsTrue(result.Any(), "Can't get any product from database");
        }

        [Test]
        public async Task GetProductsByCategory()
        {
            string categoryId = "297941281451016705";
            var result = await productRepository.GetProductsByCategory(categoryId);
            Assert.IsTrue(result.Any(), "Can't get any product from database");
        }

    }
}
